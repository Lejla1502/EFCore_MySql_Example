namespace EFCore_MySql_Example.WebApi.Responses
{
    public class PutTaskResponse:BaseResponse
    {
        public EFCore_MySql_Example.Storage.Models.Task Task { get; set; }
    }
}
