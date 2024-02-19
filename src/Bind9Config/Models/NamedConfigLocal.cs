namespace Bind9Config.Models;

/// <summary>
/// Named本地配置
/// </summary>
public class NamedConfigLocal
{
    /// <summary>
    /// Named区域
    /// </summary>
    public NamedZone[] Zones { get; set; } = [];
}
