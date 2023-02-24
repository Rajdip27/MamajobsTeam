using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;

namespace Tactsoft.Data.EntityConfigurations
{
    public class PostingJobsConfiguration : IEntityTypeConfiguration<PostingJobs>
    {
        public void Configure(EntityTypeBuilder<PostingJobs> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.JobCategory).WithMany(x => x.PostingJobs).HasForeignKey(x => x.JobCategoryeId);
            builder.HasOne(x => x.EmploymentStatus).WithMany(x => x.PostingJobs).HasForeignKey(x => x.EmploymentStatusId);
            builder.HasOne(x => x.ResumeReceivingOption).WithMany(x => x.PostingJobs).HasForeignKey(x => x.ResumeOptionId);
            builder.HasOne(x => x.JobLevel).WithMany(x => x.PostingJobs).HasForeignKey(x => x.JobLevelId);
            builder.HasOne(x => x.WorkPlace).WithMany(x => x.PostingJobs).HasForeignKey(x => x.WorkPlaceId);
            builder.HasOne(x => x.JobLocation).WithMany(x => x.PostingJobs).HasForeignKey(x => x.JobLocationId);
        }
    }
}
