﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Projeto01.Areas.Seguranca.Models
{
    public class Papel : IdentityRole
    {
        public Papel() : base () { }
        public Papel(string name) : base(name) { }
    }
}