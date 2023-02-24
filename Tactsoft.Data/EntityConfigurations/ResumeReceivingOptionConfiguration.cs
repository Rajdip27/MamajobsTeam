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
    public class ResumeReceivingOptionConfiguration : IEntityTypeConfiguration<District>



    {

        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
    
