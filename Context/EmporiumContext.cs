using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmporiumRemuneration.Models;

namespace EmporiumRemuneration.Context
{
    public class EmporiumContext : DbContext
    {
        public EmporiumContext(DbContextOptions options) : base(options)
        {

        }

        public  DbSet<ConsumerInfo> Consumers { get; set; }
        public DbSet<ProductInfo> Products { get; set; } 
        public DbSet<TranscationInformation> EmporiumTranscations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TranscationInformation>()
                .HasKey(e => new { e.CustomerID, e.TranscationID });
        }
    }
}
