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
    public class ContactPersonDesignationService : BaseService<ContactPersonDesignation>, IContactPersonDesignationService
    {
        private readonly AppDbContext _context;
        public ContactPersonDesignationService(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}