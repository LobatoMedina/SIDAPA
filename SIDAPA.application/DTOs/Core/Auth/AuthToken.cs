namespace SIDAPA.application.DTOs.Core.Auth;

public record AuthToken(string AccessToken, DateTime ExpiresAtUtc);