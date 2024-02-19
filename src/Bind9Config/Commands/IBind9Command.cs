namespace Bind9Config.Commands;

/// <summary>
/// Bind9命令
/// </summary>
public interface IBind9Command
{
    /// <summary>
    /// 重启Bind9
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RestartAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 停止Bind9
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task StopAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// 启动Bind9
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task StartAsync(CancellationToken cancellationToken = default);
}
