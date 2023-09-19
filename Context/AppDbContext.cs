using System.Net;
using Api_v1.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_v1.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Patient> Patients { get; set; }
    }
}
