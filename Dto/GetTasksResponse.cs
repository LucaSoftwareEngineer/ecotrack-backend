namespace ecotrack_backend.Dto
{
    public class GetTasksResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly DueDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
