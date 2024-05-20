using Newtonsoft.Json;
using SchoolClasses.Presentation.Contexts;
using SchoolClasses.Presentation.Models.Request;
using SchoolClasses.Presentation.Models.Response;
using System.Text;

namespace SchoolClasses.Presentation.Services
{
    public class ServiceTurma
    {
        public static async Task<bool> Add(InputTurma model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PostAsync(RoutesContext.EndpointTurma_Add, new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<bool> Update(string id, InputTurma model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PutAsync(RoutesContext.EndpointTurma_Update(id), new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<List<ViewTurma>> GetAll()
        {
            List<ViewTurma> lst = new List<ViewTurma>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(RoutesContext.EndpointTurma_GetAll);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        lst = JsonConvert.DeserializeObject<List<ViewTurma>>(responseContent);
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

                    var response = await client.PatchAsync(RoutesContext.EndpointTurma_ToggleActivate(id), new StringContent(json, Encoding.UTF8, "application/json"));
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
                    var response = await client.DeleteAsync(RoutesContext.EndpointTurma_Delete(id));
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
