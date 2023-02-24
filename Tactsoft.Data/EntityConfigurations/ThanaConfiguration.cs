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
    public class ThanaConfiguration : IEntityTypeConfiguration<Thana>



    {

        public void Configure(EntityTypeBuilder<Thana> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.District).WithMany(x => x.Thanas).HasForeignKey(x => x.DistrictId);
        }
    }
}
