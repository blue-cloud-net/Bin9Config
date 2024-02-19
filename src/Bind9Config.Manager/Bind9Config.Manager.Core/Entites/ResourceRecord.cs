using Bind9Config.Models;

namespace Bind9Config.Manager.Core.Entites;

/// <summary>
/// 资源记录
/// </summary>
public class ResourceRecord
{
    /// <summary>
    /// ZoneId
    /// </summary>
    public Guid ZoneId { get; set; }

    /// <summary>
    /// 记录
    /// </summary>
    public string Record { get; set; } = String.Empty;

    /// <summary>
    /// 类型
    /// </summary>
    public DnsRecordType Type { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string Value { get; set; } = String.Empty;
}
