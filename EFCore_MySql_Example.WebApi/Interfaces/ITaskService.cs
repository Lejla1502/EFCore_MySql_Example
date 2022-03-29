using EFCore_MySql_Example.WebApi.Responses;

namespace EFCore_MySql_Example.WebApi.Interfaces
{
    public interface ITaskService
    {
        Task<GetTasksResponse> GetTasks(int userId);
        Task<SaveTaskResponse> SaveTask(EFCore_MySql_Example.Storage.Models.Task task);
        Task<DeleteTaskResponse> DeleteTask(int taskId, int userId);

        Task<PutTaskResponse> PutTask(EFCore_MySql_Example.Storage.Models.Task task);
    }
}
