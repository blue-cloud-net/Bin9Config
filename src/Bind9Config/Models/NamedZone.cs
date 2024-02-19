namespace Bind9Config.Models;

/// <summary>
/// Named区域
/// </summary>
public struct NamedZone
{
    /// <summary>
    /// 区域名称
    /// </summary>
    public string DomainName { get; set; }

    /// <summary>
    /// 区域文件地址
    /// </summary>
    public string FilePath { get; set; }

    /// <summary>
    /// 资源记录
    /// </summary>
    public NamedResourceRecord[] Records { get; set; }
}
