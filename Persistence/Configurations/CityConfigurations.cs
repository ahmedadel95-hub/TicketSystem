using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    internal class CityConfigurations : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> modelBuilder)
        {
            modelBuilder
               .HasMany(b => b.Tickets)
               .WithOne(b => b.City)
               .HasForeignKey(b => b.CityId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .HasMany(b => b.Districts)
                .WithOne(b => b.City)
                .HasForeignKey(b => b.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
