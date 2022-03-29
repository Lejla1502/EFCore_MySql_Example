using EFCore_MySql_Example.WebApi.Requests;
using EFCore_MySql_Example.WebApi.Responses;

namespace EFCore_MySql_Example.WebApi.Interfaces
{
    public interface IUserService
    {
        Task<TokenResponse> LoginAsync(LoginRequest loginRequest);
        Task<SignupResponse> SignupAsync(SignupRequest signupRequest);
        Task<LogoutResponse> LogoutAsync(int userId);
        Task<UsersResponse> UserInfoAsync(int userId);
    }
}
