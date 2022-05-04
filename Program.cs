using Demo;
using Demo.GraphQL;
using Demo.IServices;
using Demo.Service;
using Demo.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutations>();

builder.Services.AddSingleton<IEmployeeService, EmployeeManager>();

builder.Services.AddPooledDbContextFactory<DatabaseContext>(o => o.UseSqlite("Data Source=database.db"));

var app = builder.Build();


app.MapGraphQL();

app.Run();
