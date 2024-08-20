using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Configurations
{
    internal class DistrictConfigurations : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> modelBuilder)
        {
            modelBuilder
              .HasMany(b => b.Tickets)
              .WithOne(b => b.District)
              .HasForeignKey(b => b.DistrictId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
