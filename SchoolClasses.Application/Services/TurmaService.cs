using SchoolClasses.Application.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolClasses.Application.Services
{
    public class TurmaService : ITurmaService
    {
        public void Add(InputTurma turma)
        {
            try
            {

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void Update(int id, InputTurma turma)
        {
            try
            {

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void Delete(int id)
        {
            try
            {

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void ToggleActivate(int id, ToggleActivate toggleActivate)
        {
            try
            {

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
        public void GetAll()
        {
            try
            {

            }
            catch (Exception exc)
            {
                //POSSÍVEL INPLEMENTAÇÃO DE FERRAMENTA DE OBSERVABILIDADE COMO SERILOG
                System.Diagnostics.Debug.WriteLine(exc);
            }
        }
    }
}
