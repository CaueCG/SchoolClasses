using Newtonsoft.Json;
using SchoolClasses.Presentation.Contexts;
using SchoolClasses.Presentation.Models.Request;
using System.Text;

namespace SchoolClasses.Presentation.Services
{
    public class ServiceAlunoTurma
    {
        public static async Task<bool> Add(InputAlunoTurma model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PostAsync(RoutesContext.EndpointAlunoTurma_Add, new StringContent(json, Encoding.UTF8, "application/json"));
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                    {
                        //string mensagemErros = ServiceGetErrosRequest.Get(responseContent);
                        return false;
                    }
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
                return false;
            }
        }
        public static async Task<bool> Delete(string idAluno, string idTurma)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(RoutesContext.EndpointAlunoTurma_Delete(idAluno, idTurma));
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                        return true;
                    else
                    {
                        //string mensagemErros = ServiceGetErrosRequest.Get(responseContent);
                        return false;
                    }
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
                return false;
            }
        }
    }
}
