using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class DistrictsService : BaseService<District>, IDistrictsService
    {
        private readonly AppDbContext _context;
        public DistrictsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> Dropdown()
        {
            return All().Select(x => new SelectListItem { Text = x.DistrictName, Value = x.Id.ToString() });
        }
    }
}
