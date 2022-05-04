using Demo.Models;
using Demo.IServices;
using HotChocolate.Resolvers;

namespace Demo.GraphQL
{
    public class EmployeeType: ObjectType<Employee>
    {
        protected override void Configure(IObjectTypeDescriptor<Employee> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field(x => x.Title).Type<StringType>();
            descriptor.Field(x => x.Department).Type<StringType>();
            descriptor.Field(x => x.LastUpdate).Type<DateTimeType>();
            descriptor.Field(x => x.StartDate).Type<DateTimeType>();
            descriptor.Field(x => x.Status).Type<BooleanType>();
            descriptor.Field<EmployeeResolver>(x => x.GetEmployees(default, default));
        }
    }

    public class EmployeeResolver
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeResolver([Service] IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IEnumerable<Employee> GetEmployees(Employee employee, IResolverContext context)
        {
            return _employeeService.GetAll().Where(x => x.Id == employee.Id);
        }
    }
}
