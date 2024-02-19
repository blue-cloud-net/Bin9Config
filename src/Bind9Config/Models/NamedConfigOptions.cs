namespace Bind9Config.Models;

/// <summary>
/// Named配置选项
/// </summary>
public class NamedConfigOptions
{
    /// <summary>
    /// 转发器
    /// </summary>
    public Forwardder[] Forwarders { get; set; } = [];

    /// <summary>
    /// 监听地址
    /// </summary>
    public ListenOn[] ListenOns { get; set; } = [];
}
