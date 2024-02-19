/***
* Copyright (c) 2023 Cersign All rights reserved.
* @Company: Cersign
*/

using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.Extensions.Logging;

namespace Bind9Config.Commands;

/// <summary>
/// 命令
/// </summary>
public class Command
{
    private readonly ILogger? _logger;

    /// <summary>
    /// 构造函数
    /// </summary>
    public Command()
    {
    }

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="logger"></param>
    public Command(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 基于执行Bash命令
    /// </summary>
    /// <param name="command">具体执行命令</param>
    /// <param name="timeout">具体执行命令</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> ExecuteCommandReturnResultByBashAsync(
        string command,
        int? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            throw new PlatformNotSupportedException("The bash only support Linux.");
        }

        using var returnStream = await this.ExecuteCommandByBashAsync(
            command,
            cancellationToken: cancellationToken);
        using var streamReader = new StreamReader(returnStream);

        string result = await streamReader.ReadToEndAsync(cancellationToken);

        return result;
    }

    /// <summary>
    /// 基于Bash执行命令并返回结果
    /// </summary>
    /// <param name="command">命令</param>
    /// <param name="args">参数</param>
    /// <param name="timeout">超时时间，毫秒为单位</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Stream> ExecuteCommandByBashAsync(
        string command,
        string[]? args = null,
        int? timeout = null,
        CancellationToken cancellationToken = default)
    {
        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            throw new PlatformNotSupportedException("The bash only support Linux.");
        }

        var returnStream = await this.ExecuteCommandAsync(
            "/bin/bash",
            ["-c", $"\"{command.Replace("\"", "\\\"")}\""],
            timeout,
            cancellationToken);

        return returnStream;
    }

    /// <summary>
    /// 执行命令并返回结果
    /// </summary>
    /// <param name="fileName">可执行文件</param>
    /// <param name="args">参数</param>
    /// <param name="timeout">超时时间，毫秒为单位</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<string> ExecuteCommandReturnResultAsync(
        string fileName,
        string[]? args = null,
        int? timeout = null,
        CancellationToken cancellationToken = default)
    {
        using var returnStream = await this.ExecuteCommandAsync(fileName, args, timeout, cancellationToken);

        using var streamReader = new StreamReader(returnStream);

        string result = await streamReader.ReadToEndAsync(cancellationToken);

        return result;
    }

    /// <summary>
    /// 执行命令
    /// </summary>
    /// <param name="fileName">可执行文件</param>
    /// <param name="args">参数</param>
    /// <param name="timeout">超时时间，毫秒为单位</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Stream> ExecuteCommandAsync(
        string fileName,
        string[]? args = null,
        int? timeout = null,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (String.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentNullException(nameof(fileName), $"The parameter '{nameof(fileName)}' can not be null or whitespace.");
        }

        string arg = String.Empty;
        if (args is not null or { Length: > 0 })
        {
            arg = String.Join(' ', args);
        }

        var psi = new ProcessStartInfo(fileName, arg)
        {
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            CreateNoWindow = false,
        };

        // 启动进程执行命令
        var proc = Process.Start(psi) ?? throw new Exception($"Can not exec fileName '{fileName} {arg}'.");

        var startTime = proc.StartTime;

        if (timeout.HasValue)
        {
            proc.WaitForExit(timeout.Value);
        }
        else
        {
            proc.WaitForExit();
        }

        var memeryStream = new MemoryStream();
        await proc.StandardOutput.BaseStream.CopyToAsync(memeryStream, 4096, cancellationToken);
        // 重新定位流的位置
        memeryStream.Seek(0, SeekOrigin.Begin);

        if (memeryStream.Length == 0)
        {
            await proc.StandardError.BaseStream.CopyToAsync(memeryStream, 4096, cancellationToken);
            // 重新定位流的位置
            memeryStream.Seek(0, SeekOrigin.Begin);
        }

        if (!proc.HasExited)
        {
            proc.Kill();
        }

        _logger?.LogInformation($"Run fileName '{fileName}' with exited code '{proc.ExitCode}'");
        _logger?.LogDebug($"Total execute time :{(proc.ExitTime - startTime).TotalMilliseconds} ms");

        proc.Close();

        return memeryStream;
    }
}
