using ECommerce.Models;

namespace ECommerce.Interfaces
{
    public interface ITokenService
    {
        Task<string?> CreateToken(AppUser user);
    }
}
