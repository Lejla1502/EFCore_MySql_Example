namespace EFCore_MySql_Example.WebApi.Responses
{
    public class GetTasksResponse: BaseResponse
    {

        public List<EFCore_MySql_Example.Storage.Models.Task> Tasks { get; set; }
    }
}
