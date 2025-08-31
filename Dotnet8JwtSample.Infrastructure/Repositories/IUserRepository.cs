using Dotnet8JwtSample.Domain.Entities;

namespace Dotnet8JwtSample.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
    }
}