using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartCampingWeb.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace SmartCampingWeb.Controllers
{
    public class AlojamentosController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiPath = "https://localhost:7048/smartcamping/";

        public AlojamentosController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var requestTipoAlojamentos = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "TipoAlojamentos");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var responseTipo = await client.SendAsync(requestTipoAlojamentos);

            var tipos = new List<TipoAlojamento>();

            if (responseTipo.IsSuccessStatusCode)
            {
                using var responseStream = await responseTipo.Content.ReadAsStreamAsync();
                var tipoAlojamentos = await JsonSerializer.DeserializeAsync<List<TipoAlojamento>>
                    (responseStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                ViewBag.TipoAlojamentos = tipoAlojamentos;
                tipos = tipoAlojamentos;
            }

            var requestAlojamentos = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Alojamentos");

            var response = await client.SendAsync(requestAlojamentos);

            var list = new List<Alojamento>();

            if(response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var alojamentos = await JsonSerializer.DeserializeAsync
                    <List<Alojamento>>(responseStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                ViewBag.Alojamentos = alojamentos;
                list = alojamentos;
            }
            else
            {
                ViewBag.Alojamentos = new List<Alojamento>();
            }

            ViewData["TipoAlojamentoId"] = new SelectList(tipos, "TipoAlojamentoId", "Tipo");

            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var requestTipoAlojamentos = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "TipoAlojamentos");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var response = await client.SendAsync(requestTipoAlojamentos);

            var tipos = new List<TipoAlojamento>();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var tipoAlojamentos = await JsonSerializer.DeserializeAsync<List<TipoAlojamento>>
                    (responseStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                tipos = tipoAlojamentos;
            }

            ViewData["TipoAlojamentoId"] = new SelectList(tipos, "TipoAlojamentoId", "Tipo");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(Alojamento alojamento)
        {
            var requestPostAlojamento = new HttpRequestMessage(HttpMethod.Post,
                apiPath + "Alojamentos/");

            requestPostAlojamento.Content = new StringContent(
                JsonSerializer.Serialize(alojamento,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                Encoding.UTF8, "application/json");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var response = await client.PostAsJsonAsync(
                apiPath + "Alojamentos/", alojamento);
            response.EnsureSuccessStatusCode();

            return Redirect("/Alojamentos/Index");
        }

        [Route("/Alojamentos/{id:int}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var requestAlojamento = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Alojamentos/" + id);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var alojamentoEditar = new Alojamento();

            var response = await client.SendAsync(requestAlojamento);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var alojamento = await JsonSerializer.DeserializeAsync
                    <Alojamento>(responseStream, new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true});
                alojamentoEditar = alojamento;

                var requestTipoAlojamentos = new HttpRequestMessage(HttpMethod.Get,
                    apiPath + "TipoAlojamentos");

                var responseTipo = await client.SendAsync(requestTipoAlojamentos);

                var tipos = new List<TipoAlojamento>();

                if (responseTipo.IsSuccessStatusCode)
                {
                    using var stream = await responseTipo.Content.ReadAsStreamAsync();
                    var tipoAlojamentos = await JsonSerializer.DeserializeAsync
                        <List<TipoAlojamento>>
                        (stream, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                    tipos = tipoAlojamentos;
                }

                ViewData["TipoAlojamentoId"] = new SelectList(tipos, "TipoAlojamentoId", "Tipo");
            }
            else
            {
                return Redirect("/Alojamentos/Index");
            }

            return View(alojamentoEditar);
        }

        [HttpPost]
        [Route("/Alojamentos/{id:int}/Edit")]
        public async Task<IActionResult> Edit(Alojamento novo, int id)
        {
            var requestAlojamento = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Alojamentos/" + id);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var response = await client.SendAsync(requestAlojamento);

            Alojamento aloj = new Alojamento();

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync();
                aloj = await JsonSerializer.DeserializeAsync<Alojamento>
                    (stream, new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true});
            }

            var requestPutAlojamento = new HttpRequestMessage(HttpMethod.Put,
                apiPath + "Alojamentos/" + id);

            novo.AlojamentoId = id;

            requestPutAlojamento.Content = new StringContent(
                JsonSerializer.Serialize(novo, new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true }), Encoding.UTF8, "application/json");

            await client.SendAsync(requestPutAlojamento);

            return Redirect("/Alojamentos/Index");
        }

        [HttpGet]
        [Route("/Alojamentos/Details/{id:int}")]
        public async Task<IActionResult> DetailS(int id)
        {
            var requestAlojamento = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Alojamentos/" + id);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var response = await client.SendAsync(requestAlojamento);

            var alojamento = new Alojamento();

            if (response.IsSuccessStatusCode)
            {
                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();
                    alojamento = await JsonSerializer.DeserializeAsync<Alojamento>
                        (stream, new JsonSerializerOptions
                        { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return Redirect("/Alojamentos/Index");
                }
            }

            var requestTipoAlojamento = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "TipoAlojamentos/" + alojamento.TipoAlojamentoId);

            var responseTipo = await client.SendAsync(requestTipoAlojamento);

            var tipoAlojamento = "";

            if (responseTipo.IsSuccessStatusCode)   
            {
                using var stream2 = await responseTipo.Content.ReadAsStreamAsync();
                var tipo = await JsonSerializer.DeserializeAsync<TipoAlojamento>
                    (stream2, new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true });

                tipoAlojamento = tipo.Tipo;
                ViewBag.Tipo = tipoAlojamento;
            }

            return View(alojamento);
        }

    }
}
