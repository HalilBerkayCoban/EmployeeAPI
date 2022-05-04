namespace Demo.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Department { get; set; }
        public int Age { get; set; }
        public DateTimeOffset? LastUpdate { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public bool? Status { get; set; }

    }
}
