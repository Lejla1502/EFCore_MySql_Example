using System.Text.Json.Serialization;

namespace EFCore_MySql_Example.WebApi.Responses
{
    public class DeleteTaskResponse:BaseResponse
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int TaskId { get; set; }
    }
}
