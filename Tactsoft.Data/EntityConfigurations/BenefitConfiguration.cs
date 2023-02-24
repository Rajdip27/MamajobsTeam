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
    public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>



    {

        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.JobPost).WithMany(x => x.Benefits).HasForeignKey(x => x.JobPostId);
            builder.HasOne(x => x.OtherBenefitType).WithMany(x => x.Benefits).HasForeignKey(x => x.OtherBenefitTypeId);
           
        }
    }
}
