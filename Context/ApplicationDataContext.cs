using AMS3ASales.API.Domain;
using AMS3ASales.API.Domain.Request;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AMS3ASales.API.Context
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}
