using Demo.Context;
using Demo.Exceptions;
using Demo.IServices;
using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service
{
    public class EmployeeManager : IEmployeeService
    {

        private IList<Employee> _employees;
        private readonly DatabaseContext _databaseContext;

        public EmployeeManager(IDbContextFactory<DatabaseContext> databaseContext)
        {
            _databaseContext = databaseContext.CreateDbContext();
        }

        public async Task<Employee> Add(CreateEmployeeInput inputEmployee)
        {
            var data = new Employee
            {
                Name = inputEmployee.Name,
                Title = inputEmployee.Title,
                Department = inputEmployee.Department,
                Age = inputEmployee.Age,
                LastUpdate = DateTimeOffset.Now,
                StartDate = inputEmployee.StartDate,
                Status = true,
            };
            _databaseContext.Employees.Add(data);
            await _databaseContext.SaveChangesAsync();
            return data;
        }

        public IQueryable<Employee> GetAll()
        {
            return _databaseContext.Employees.AsQueryable();
        }

        public async Task<Employee> Update(UpdateEmployeeInput inputEmployee)
        {
            var employee = await _databaseContext.Employees.FirstOrDefaultAsync(x => x.Id == inputEmployee.Id);
            if(employee == null)
            {
                throw new EmployeeNotFoundException();
            }
            employee.Name = inputEmployee.Name;
            employee.Title = inputEmployee.Title;
            employee.Department = inputEmployee.Department;
            employee.Age = inputEmployee.Age;
            employee.LastUpdate = DateTimeOffset.Now;
            employee.StartDate = DateTimeOffset.Now;
            employee.Status = inputEmployee.Status;
            await _databaseContext.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Delete(DeleteEmployeeInput inputEmployee)
        {
            var employee = await _databaseContext.Employees.FirstOrDefaultAsync(x => x.Id == inputEmployee.Id);
            if(employee == null)
            {
                throw new EmployeeNotFoundException();
            }
            _databaseContext.Employees.Remove(employee);
            await _databaseContext.SaveChangesAsync();
            return employee;
        }

        public Task<Employee> GetById(Guid id)
        {
            return _databaseContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
