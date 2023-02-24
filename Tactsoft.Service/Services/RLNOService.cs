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
    public class RLNOService : BaseService<RLNO>, IRLNOService
    {
        private readonly AppDbContext _context;
        public RLNOService(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}