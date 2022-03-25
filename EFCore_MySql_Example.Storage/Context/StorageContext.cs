using EFCore_MySql_Example.Storage.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MySql_Example.Storage.Context
{
    public class StorageContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public StorageContext(DbContextOptions pOptions) : base(pOptions)
        {
        }
    }
}
