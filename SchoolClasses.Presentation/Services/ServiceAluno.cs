using Newtonsoft.Json;
using SchoolClasses.Presentation.Contexts;
using SchoolClasses.Presentation.Models.Request;
using SchoolClasses.Presentation.Models.Response;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace SchoolClasses.Presentation.Services
{
    public class ServiceAluno
    {
        public static async Task<bool> Add(InputAluno model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PostAsync(RoutesContext.EndpointAlunos_Add, new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<bool> Update(string id, InputAluno model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PutAsync(RoutesContext.EndpointAlunos_Update(id), new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<List<ViewAluno>> GetAll()
        {
            List<ViewAluno> lst = new List<ViewAluno>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(RoutesContext.EndpointAlunos_GetAll);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        lst = JsonConvert.DeserializeObject<List<ViewAluno>>(responseContent);
                        return lst;
                    }
                    else
                    {
                        //string mensagemErros = ServiceGetErrosRequest.Get(responseContent);
                        return lst;
                    }
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
                return lst;
            }
        }

        public static async Task<List<ViewAluno>> GetByIdTurma(string idTurma)
        {
            List<ViewAluno> lst = new List<ViewAluno>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(RoutesContext.EndpointAlunos_GetByIdTurma(idTurma));
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        lst = JsonConvert.DeserializeObject<List<ViewAluno>>(responseContent);
                        return lst;
                    }
                    else
                    {
                        //string mensagemErros = ServiceGetErrosRequest.Get(responseContent);
                        return lst;
                    }
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc);
                return lst;
            }
        }

        public static async Task<bool> ToggleActivate(string id, ToggleActivate model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PatchAsync(RoutesContext.EndpointAlunos_Update(id), new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<bool> Delete(string id)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(RoutesContext.EndpointAlunos_Delete(id));
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
