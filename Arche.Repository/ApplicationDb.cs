using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arche.Domain;
using Microsoft.EntityFrameworkCore;

namespace Arche.Repository.Data
{
    public class ApplicationDb:DbContext
    {
        public ApplicationDb(DbContextOptions<ApplicationDb> options) : base(options)
        { 
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<UserLogin> users { get; set; }
    }
}
