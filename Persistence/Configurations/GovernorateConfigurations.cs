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
    internal class GovernorateConfigurations : IEntityTypeConfiguration<Governorate>
    {
        public void Configure(EntityTypeBuilder<Governorate> modelBuilder)
        {
            modelBuilder
              .HasMany(b => b.Tickets)
              .WithOne(b => b.Governorate)
              .HasForeignKey(b => b.GovernorateId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .HasMany(b => b.Cities)
                .WithOne(b => b.Governorate)
                .HasForeignKey(b => b.GovernorateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
