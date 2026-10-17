namespace SIDAPA.application.Interface.Core;

/// <summary>Hash de contraseñas con sal y algoritmo lento.</summary>
public interface IPasswordHasher
{
    string Hash(string password);

    bool Verify(string passwordHash, string password);
}
