namespace EFCore_MySql_Example.WebApi.Responses
{
    public class GetTasksResponse: BaseResponse
    {

        public List<Task> Tasks { get; set; }
    }
}
