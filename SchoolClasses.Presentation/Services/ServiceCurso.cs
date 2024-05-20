using Newtonsoft.Json;
using SchoolClasses.Presentation.Contexts;
using SchoolClasses.Presentation.Models.Request;
using SchoolClasses.Presentation.Models.Response;
using System.Text;

namespace SchoolClasses.Presentation.Services
{
    public class ServiceCurso
    {
        public static async Task<bool> Add(InputCurso model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PostAsync(RoutesContext.EndpointCurso_Add, new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<bool> Update(string id, InputCurso model)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string json = JsonConvert.SerializeObject(model);

                    var response = await client.PutAsync(RoutesContext.EndpointCurso_Update(id), new StringContent(json, Encoding.UTF8, "application/json"));
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

        public static async Task<List<ViewCurso>> GetAll()
        {
            List<ViewCurso> lst = new List<ViewCurso>();

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(RoutesContext.EndpointCurso_GetAll);
                    var responseContent = await response.Content.ReadAsStringAsync();
                    if (response.IsSuccessStatusCode)
                    {
                        lst = JsonConvert.DeserializeObject<List<ViewCurso>>(responseContent);
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

        public static async Task<bool> Delete(string id)
        {
            #region Validate
            #endregion

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.DeleteAsync(RoutesContext.EndpointCurso_Delete(id));
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
