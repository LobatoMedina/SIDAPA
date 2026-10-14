using Microsoft.EntityFrameworkCore;
using SIDAPA.application.Interface.Core;
using SIDAPA.domain.Entities.Core.Operative;
using SIDAPA.infraestructure.Persistence;

namespace SIDAPA.infraestructure.Repositories;

public class UserRepository(SidapaDbContext context) : IUserRepository
{
    public Task<UserEntity?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        var normalized = email.ToLowerInvariant();

        return context.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email.ToLower() == normalized, ct);
    }
}
