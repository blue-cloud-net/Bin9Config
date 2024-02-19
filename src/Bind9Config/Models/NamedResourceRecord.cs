namespace Bind9Config.Models;

/// <summary>
/// 资源记录
/// </summary>
public struct NamedResourceRecord
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 记录
    /// </summary>
    public string Record { get; set; }

    /// <summary>
    /// 类型
    /// </summary>
    public DnsRecordType Type { get; set; }

    /// <summary>
    /// 值
    /// </summary>
    public string Value { get; set; }


    /// <inheritdoc/>
    public override readonly string ToString()
    {
        return $"{this.Record}\t\t\t\t\t\tIN\t\t{Enum.GetName(this.Type)!.ToUpperInvariant()}\t{this.Value}";
    }
}
