using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>



    {

        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Countrys).WithMany(x => x.Districts).HasForeignKey(x => x.CountrysId);

        }
    }
}
