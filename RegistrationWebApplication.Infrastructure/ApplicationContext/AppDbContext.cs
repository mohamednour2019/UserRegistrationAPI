using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegistrationWebApplication.Core.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationWebApplication.Infrastructure.ApplicationContext
{
    public class AppDbContext:DbContext
    {
        public DbSet<User> Users {  get; set; }

        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration):base()
        {
            _configuration= configuration;  
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string constr = _configuration["ConnectionStrings:Default"]!.ToString();
            optionsBuilder.UseSqlServer(constr);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
