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
        private readonly IConfiguration _configuration;

        public ContextDb(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlConnectionString"));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<ReplacedPart> ReplacedParts { get; set; }
        public DbSet<ServiceInformation> ServiceInformations { get; set; }
    }
}
