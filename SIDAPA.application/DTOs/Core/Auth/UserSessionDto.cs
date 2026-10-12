namespace SIDAPA.application.DTOs.Core.Auth;

public record UserSessionDto(int UserId, string Name, string Email, string Role, int? ClientId);