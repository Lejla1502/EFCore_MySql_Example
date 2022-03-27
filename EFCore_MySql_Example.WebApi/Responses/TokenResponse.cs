namespace EFCore_MySql_Example.WebApi.Responses
{
    public class TokenResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        /*
         public Id UserId {get; set;}
        public firstName{get; set; }
         */
    }
}
