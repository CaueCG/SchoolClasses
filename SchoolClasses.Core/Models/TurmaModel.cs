﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Core.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        public CursoModel Curso { get; set; } = new CursoModel();
        public string Nome { get; set; }
        public int Ano { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
