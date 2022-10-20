using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Service.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataAccess.Concrete.EntityFramework.Context
{
    public class ContextDb : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1455;database=TechnicalServiceDb;user=sa;password=Asd159123159123!");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ReplacedPart> ReplacedParts { get; set; }
        public DbSet<ServiceInformation> ServiceInformations { get; set; }
    }
}
