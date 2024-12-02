using ECommerce.Models;

namespace ECommerce.Interfaces.Service
{
    public interface ITokenService
    {
        Task<string?> CreateToken(AppUser user);
    }
}
