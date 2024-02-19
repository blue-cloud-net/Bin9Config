namespace Bind9Config.Manager.Core.Entites;

/// <summary>
/// 账户
/// </summary>
public class Account
{
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = String.Empty;

    /// <summary>
    /// 密码
    /// </summary>
    public string Passward { get; set; } = String.Empty;
}
