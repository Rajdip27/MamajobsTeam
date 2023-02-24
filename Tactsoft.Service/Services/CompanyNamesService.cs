using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;
using static System.Net.Mime.MediaTypeNames;

namespace Tactsoft.Service.Services
{
    public class CompanyNamesService : BaseService<CompanyName>, ICompanyNamesService
    {
        private readonly AppDbContext _context;
        public CompanyNamesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

      
        
    }
}
