namespace SIDAPA.infraestructure.Security;

public class JwtOptions
{
    public string Issuer { get; set;} = "SIDAPA";
    public string Audience { get; set;} = "SIDAPA";
    public string Key { get; set; } = "";
    public int ExpiresMinutes {get; set; } = 30;
}