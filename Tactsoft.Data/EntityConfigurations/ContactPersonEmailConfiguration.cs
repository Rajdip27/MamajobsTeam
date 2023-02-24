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
    public  class ContactPersonEmailConfiguration : IEntityTypeConfiguration<ContactPersonEmail>


    {

        public void Configure(EntityTypeBuilder<ContactPersonEmail> builder)
        {
            builder.HasKey(x => x.Id);


        }


    }
}