using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using _Core.Domain;
namespace _Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees  { get; set; }
    }
}
