﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Core.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
