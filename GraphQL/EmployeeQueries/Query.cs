using Demo.Context;
using Demo.IServices;
using Demo.Models;

namespace Demo.GraphQL
{
    public class Query
    {
        private readonly IEmployeeService _employeeService;

        public Query(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IQueryable<Employee> Employees => _employeeService.GetAll();
        
    }
}
