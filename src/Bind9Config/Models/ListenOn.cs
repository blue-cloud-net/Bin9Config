namespace Bind9Config.Models;

/// <summary>
/// 监听
/// </summary>
public struct ListenOn
{
    /// <summary>
    /// 地址
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// 端口
    /// </summary>
    public int Port { get; set; }
}
