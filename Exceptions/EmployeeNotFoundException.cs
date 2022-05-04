namespace Demo.Exceptions
{
    public class EmployeeNotFoundException: Exception
    {
        public Guid EmployeeId { get; internal set; }
    }
}
