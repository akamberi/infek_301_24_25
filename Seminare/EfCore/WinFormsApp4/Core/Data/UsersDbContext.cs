using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4.Core.Data
{
    internal class UsersDbContext : DbContext
    {
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(
                        new DbContextOptionsBuilder(), connectionString).Options;
        }

        public UsersDbContext(string connectionString) : base(GetOptions(connectionString))
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
