using FE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FE.Servicios
{
    public class VinculoProductoServicio : IVinculoProductoServicio
    {
        public void Delete(VinculoProducto t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    cl.DefaultRequestHeaders.Clear();
                    cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage res = cl.DeleteAsync("api/VinculoProducto/" + t.IdVinculoProducto.ToString()).Result;

                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception(res.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public IEnumerable<VinculoProducto> GetAll()
        {
            List<Models.VinculoProducto> aux = new List<Models.VinculoProducto>();

            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/VinculoProducto").Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.VinculoProducto>>(auxres);
                }
            }
            return aux;
        }

        public async Task<IEnumerable<VinculoProducto>> GetAllAsync()
        {
            List<Models.VinculoProducto> aux = new List<Models.VinculoProducto>();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/VinculoProducto");

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<List<Models.VinculoProducto>>(auxres);
                }
            }
            return aux;
        }

        public VinculoProducto GetOneById(int id)
        {
            Models.VinculoProducto aux = new Models.VinculoProducto();

            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = cl.GetAsync("api/VinculoProducto/" + id).Result;

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.VinculoProducto>(auxres);
                }
            }
            return aux;
        }

        public async Task<VinculoProducto> GetOneByIdAsync(int id)
        {
            Models.VinculoProducto aux = new Models.VinculoProducto();
            using (var cl = new HttpClient())
            {
                cl.BaseAddress = new Uri(Program.baseurl);
                cl.DefaultRequestHeaders.Clear();
                cl.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await cl.GetAsync("api/VinculoProducto/" + id);

                if (res.IsSuccessStatusCode)
                {
                    var auxres = res.Content.ReadAsStringAsync().Result;
                    aux = JsonConvert.DeserializeObject<Models.VinculoProducto>(auxres);
                }
            }
            return aux;
        }

        public void Insert(VinculoProducto t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(t);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PostAsync("api/VinculoProducto", byteContent).Result;

                    if (!postTask.IsSuccessStatusCode)
                    {
                        throw new Exception(postTask.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }

        public void Update(VinculoProducto t)
        {
            try
            {
                using (var cl = new HttpClient())
                {
                    cl.BaseAddress = new Uri(Program.baseurl);
                    var content = JsonConvert.SerializeObject(t);
                    var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                    var byteContent = new ByteArrayContent(buffer);
                    byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    var postTask = cl.PutAsync("api/VinculoProducto/" + t.IdVinculoProducto, byteContent).Result;


                    if (!postTask.IsSuccessStatusCode)
                    {
                        throw new Exception(postTask.Content.ToString());
                    }
                }
            }
            catch (Exception ee)
            {
                throw ee;
            }
        }
    }
}
