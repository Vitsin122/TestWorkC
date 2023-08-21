using Microsoft.EntityFrameworkCore;
using TestWorkC.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace TestWorkC.DataContext
{
    public class NpgApplicationContext : DbContext
    {
        //ConnectionString = Configuration["Connnectionstrings:MyConnection"];
        public DbSet<DrillBlock> DrillBlocks { get; set; }
        public DbSet<DrillBlockPoints> DrillBlocksPoints { get; set;}
        public DbSet<Hole> Holes { get; set; }
        public DbSet<HolePoints> HolePoints { get; set; }

        public NpgApplicationContext(DbContextOptions<NpgApplicationContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=vitalya122;Database=IndustrialDB");
        }

    }
}
