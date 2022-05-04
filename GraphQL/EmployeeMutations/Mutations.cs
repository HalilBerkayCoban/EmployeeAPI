using Demo.IServices;
using Demo.Models;

namespace Demo.GraphQL
{
    public class Mutations
    {
        private readonly IEmployeeService _employeeService;

        public Mutations(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<Employee> Add(CreateEmployeeInput inputEmployee) => await _employeeService.Add(inputEmployee);

        public async Task<Employee> Delete(DeleteEmployeeInput inputEmployee) => await _employeeService.Delete(inputEmployee);

        public async Task<Employee> Update(UpdateEmployeeInput inputEmployee) => await _employeeService.Update(inputEmployee);
  
    }
}
