using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.ResponseModels
{
    public class ViewBaseResponse
    {
        public ViewBaseResponse() =>
            Errors = new List<string>();

        public List<string> Errors { get; private set; }
        public bool Success => Errors.Count == 0;

        public void AddErrorMessage(string erro) =>
            Errors.Add(erro);
    }
}
