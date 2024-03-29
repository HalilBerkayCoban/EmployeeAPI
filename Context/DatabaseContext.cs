﻿using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<Employee>? Employees { get; set; }
    }
}
