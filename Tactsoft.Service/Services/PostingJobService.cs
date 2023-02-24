using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class PostingJobService : BaseService<PostingJobs>, IPostingJobService
    {
        private readonly AppDbContext appDbContext;
        public PostingJobService(AppDbContext context) : base(context)
        {
            this.appDbContext = context;
        }
    }
}
