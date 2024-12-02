using ECommerce.DTOs.Account;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterCustomerAsync(CustomerRegisterDto customerRegisterDto);
        Task<IdentityResult> RegisterStaffAsync(StaffRegisterDto staffRegisterDto);
        Task<IdentityResult> RegisterSuperAdminAsync(SuperAdminRegisterDto superAdminRegisterDto);
        Task<AppUser> FindUserByUsernameAsync(string username);
        Task<bool> CheckPasswordAsync(AppUser user, string password);
        Task<string> CreateTokenAsync(AppUser user);
    }
}
