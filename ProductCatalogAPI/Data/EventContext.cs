using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class EventContext : DbContext
    {
        //this "options" is given from the startup file
        public EventContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }

        //providing the rules to create the table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventType>(e =>
            {
                e.Property(t => t.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Event>(e =>
            {
                e.Property(E => E.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                e.Property(E => E.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(E => E.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                e.Property(E => E.Location)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(E => E.Date)
                    .IsRequired()
                    .HasMaxLength(100);

                e.Property(E => E.Price)
                    .IsRequired();

                //defining the foreign key relationship

                e.HasOne(E => E.EventType)
                    .WithMany()
                    .HasForeignKey(E => E.EventTypeId);


            });
        }
    }
}
