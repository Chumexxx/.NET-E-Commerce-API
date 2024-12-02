using ECommerce.DTOs.Account;

namespace ECommerce.Interfaces.Service
{
    public interface IAccountService
    {
        Task<SignedInDto> RegisterCustomerAsync(CustomerRegisterDto customerRegisterDto);
        Task<SignedInDto> RegisterStaffAsync(StaffRegisterDto staffRegisterDto);
        Task<SignedInDto> RegisterSuperAdminAsync(SuperAdminRegisterDto superAdminRegisterDto);
        Task<NewUserDto> LoginAsync(LoginDto loginDto);
    }
}
