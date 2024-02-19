using Microsoft.Extensions.Logging;

namespace Bind9Config.Commands;

/// <inheritdoc cref="IBind9Command"/>
public class Bind9Command : Command, IBind9Command
{
    /// <summary>
    /// 构造函数注入
    /// </summary>
    /// <param name="logger"></param>
    public Bind9Command(
        ILogger<Bind9Command> logger) : base(logger)
    {
    }

    /// <inheritdoc/>
    public async Task RestartAsync(CancellationToken cancellationToken = default)
    {
        var commandResult = await base.ExecuteCommandReturnResultAsync(
            "systemctl", new string[] { "restart bind9" }, cancellationToken: cancellationToken);

        if (String.IsNullOrWhiteSpace(commandResult))
        {
            return;
        }
        else
        {
            throw new Exception(commandResult);
        }
    }

    /// <inheritdoc/>
    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        var commandResult = await base.ExecuteCommandReturnResultAsync(
            "systemctl", new string[] { "start bind9" }, cancellationToken: cancellationToken);

        if (String.IsNullOrWhiteSpace(commandResult))
        {
            return;
        }
        else
        {
            throw new Exception(commandResult);
        }
    }

    /// <inheritdoc/>
    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        var commandResult = await base.ExecuteCommandReturnResultAsync(
            "systemctl", new string[] { "stop bind9" }, cancellationToken: cancellationToken);

        if (String.IsNullOrWhiteSpace(commandResult))
        {
            return;
        }
        else
        {
            throw new Exception(commandResult);
        }
    }
}
