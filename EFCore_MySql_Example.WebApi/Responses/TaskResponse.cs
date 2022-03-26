namespace EFCore_MySql_Example.WebApi.Responses
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Ts { get; set; }
    }
}
