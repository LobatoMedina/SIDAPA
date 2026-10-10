using SIDAPA.application.DTOs.Core.Auth;

namespace SIDAPA.application.Interface.Core;

public interface ITokenService
{
    AuthToken CreateToken(UserSessionDto user);
}