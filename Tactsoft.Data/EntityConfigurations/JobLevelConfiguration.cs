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
    public class JobLevelConfiguration : IEntityTypeConfiguration<JobLevel>



    {

        public void Configure(EntityTypeBuilder<JobLevel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}