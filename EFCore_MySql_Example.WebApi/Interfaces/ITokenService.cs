using EFCore_MySql_Example.Storage.Models;
using EFCore_MySql_Example.WebApi.Requests;
using EFCore_MySql_Example.WebApi.Responses;

namespace EFCore_MySql_Example.WebApi.Interfaces
{
    public interface ITokenService
    {
        Task<Tuple<string, string>> GenerateTokensAsync(int userId);
        Task<ValidateRefreshTokenResponse> ValidateRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest);
        Task<bool> RemoveRefreshTokenAsync(User user);
    }
}
