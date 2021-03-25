using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication1.Data
{
    public class WebApplication1Context : DbContext
    {
        public DbSet<Models.Duckbill> Duckbill { get; set; }

        public WebApplication1Context(DbContextOptions<WebApplication1Context> options)
            : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Duckbill>().HasData(new Models.Duckbill() { ID = new Guid("c9f777a1-6166-471a-87db-2ef29ed1cd5a"), Name = "Duckbill1", DateOfBirth = new DateTime(2021, 01, 01) });
        }
    }
}