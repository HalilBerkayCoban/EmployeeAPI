﻿using Demo.Models;

namespace Demo.IServices
{
    public interface IEmployeeService
    {
        IQueryable<Employee> GetAll();
        Task<Employee> Add(CreateEmployeeInput inputEmployee);
        Task<Employee> Update(UpdateEmployeeInput inputEmployee);
        Task<Employee> Delete(DeleteEmployeeInput inputEmployee);
    }
}
