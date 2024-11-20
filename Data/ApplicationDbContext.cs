using BlazorDemoPOC.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemoPOC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Test> Test { get; set; }
        public DbSet<Person> Person {get; set;}
    }
}
