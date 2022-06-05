using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TownGameBot.Models
{
    public class AplicationContext : DbContext
    {
        public DbSet<CityModel> Cities { get; set; }

        public AplicationContext(DbContextOptions<AplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
