using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}
