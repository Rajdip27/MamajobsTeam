﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tactsoft.Core.Base;

namespace Tactsoft.Core.Entities
{
    public class Establishment : BaseEntity
    {
        [Display(Name = "Establishment Name")]
        public string  EstablishmentName { get; set; }  
    }
}
