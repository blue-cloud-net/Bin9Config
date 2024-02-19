namespace Bind9Config.Models;

/// <summary>
/// Dns记录类型
/// </summary>
public enum DnsRecordType
{
    /// <summary>
    ///   Invalid record type
    /// </summary>
    Invalid = 0,

    /// <summary>
    ///   <para>Host address</para>
    ///   <para>
    ///     Defined in
    ///     <a href="https://www.rfc-editor.org/rfc/rfc1035.html">RFC 1035</a>.
    ///   </para>
    /// </summary>
    A = 1,

    /// <summary>
    ///   <para>Authoritatitve name server</para>
    ///   <para>
    ///     Defined in
    ///     <a href="https://www.rfc-editor.org/rfc/rfc1035.html">RFC 1035</a>.
    ///   </para>
    /// </summary>
    Ns = 2,

    /// <summary>
    ///   <para>Canonical name for an alias</para>
    ///   <para>
    ///     Defined in
    ///     <a href="https://www.rfc-editor.org/rfc/rfc1035.html">RFC 1035</a>.
    ///   </para>
    /// </summary>
    CName = 5,

    /// <summary>
    ///   <para>Text strings</para>
    ///   <para>
    ///     Defined in
    ///     <a href="https://www.rfc-editor.org/rfc/rfc1035.html">RFC 1035</a>.
    ///   </para>
    /// </summary>
    Txt = 16,

    /// <summary>
    ///   <para>IPv6 address</para>
    ///   <para>
    ///     Defined in
    ///     <a href="https://www.rfc-editor.org/rfc/rfc3596.html">RFC 3596</a>.
    ///   </para>
    /// </summary>
    Aaaa = 28,
}
