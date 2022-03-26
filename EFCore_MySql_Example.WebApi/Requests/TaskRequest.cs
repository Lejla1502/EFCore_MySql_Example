namespace EFCore_MySql_Example.WebApi.Requests
{
    public class TaskRequest
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Ts { get; set; }
    }
}
