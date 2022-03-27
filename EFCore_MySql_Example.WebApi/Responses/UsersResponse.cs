namespace EFCore_MySql_Example.WebApi.Responses
{
    public class UsersResponse:BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
