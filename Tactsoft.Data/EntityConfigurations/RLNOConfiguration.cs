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
    public  class RLNOConfiguration : IEntityTypeConfiguration<RLNO>


    {

        public void Configure(EntityTypeBuilder<RLNO> builder)
        {
            builder.HasKey(x => x.Id);


        }


    }
}