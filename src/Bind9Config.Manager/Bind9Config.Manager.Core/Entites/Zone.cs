namespace Bind9Config.Manager.Core.Entites;

/// <summary>
/// Zone
/// </summary>
public class Zone
{
    /// <summary>
    /// 区域名称
    /// </summary>
    public string DomainName { get; set; }

    /// <summary>
    /// 区域文件地址
    /// </summary>
    public string FilePath { get; set; }
}
