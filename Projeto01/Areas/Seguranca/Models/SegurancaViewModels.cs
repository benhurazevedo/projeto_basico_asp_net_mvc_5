﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projeto01.Areas.Seguranca.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}