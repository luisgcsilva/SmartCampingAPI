using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SmartCampingWeb.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web.WebPages;

namespace SmartCampingWeb.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private string apiPath = "https://localhost:7048/smartcamping/";

        public ReservasController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("userType") == "1")
            {
                var cliente = HttpContext.Session.GetString("clienteId").AsInt();
                var requestReservas = new HttpRequestMessage(HttpMethod.Get,
                    apiPath + "Clientes/" + cliente + "/reservas");

                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Token", token);

                var response = await client.SendAsync(requestReservas);

                var listReservas = new List<Reserva>();

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var reservas = await JsonSerializer.DeserializeAsync<List<Reserva>>
                        (responseStream, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    listReservas = reservas;
                }

                ViewBag.UserType = HttpContext.Session.GetString("userType");
                return View(listReservas);
            }
            if (HttpContext.Session.GetString("userType") == "2" || HttpContext.Session.GetString("userType") == "3")
            {
                var requestReservas = new HttpRequestMessage(HttpMethod.Get,
                    apiPath + "Reservas");

                var client = _clientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var token = HttpContext.Session.GetString("token");
                client.DefaultRequestHeaders.Add("Token", token);

                var response = await client.SendAsync(requestReservas);

                var listReservas = new List<Reserva>();

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var reservas = await JsonSerializer.DeserializeAsync<List<Reserva>>
                        (responseStream, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });
                    listReservas = reservas;
                }

                ViewBag.UserType = HttpContext.Session.GetString("userType");
                return View(listReservas);
            }

            ViewBag.UserType = HttpContext.Session.GetString("userType");
            return View();
        }

        [HttpGet]
        [Route("/Reservas/Details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var requestReserva = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Reservas/" + id);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var response = await client.SendAsync(requestReserva);

            var reserva = new Reserva();

            if (response.IsSuccessStatusCode)
            {
                if (response.IsSuccessStatusCode)
                {
                    using var stream = await response.Content.ReadAsStreamAsync();
                    reserva = await JsonSerializer.DeserializeAsync<Reserva>
                        (stream, new JsonSerializerOptions
                        { PropertyNameCaseInsensitive = true });
                }
                else
                {
                    return Redirect("/Reservas/Index");
                }
            }

            ViewBag.UserType = HttpContext.Session.GetString("userType");
            return View(reserva);
        }

        public async Task<IActionResult> Create()
        {
            var requestMetodosPagamento = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "MetodoPagamentos");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var response = await client.SendAsync(requestMetodosPagamento);

            var metodos = new List<MetodoPagamento>();

            if(response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var metodoPagamentos = await JsonSerializer.DeserializeAsync<List<MetodoPagamento>>
                    (responseStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                metodos = metodoPagamentos;
            }

            ViewBag.UserType = HttpContext.Session.GetString("userType");
            ViewData["MetodoPagamentoId"] = new SelectList(metodos, "MetodoPagamentoId", "Metodo");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Store(Reserva reserva)
        {
            var requestPostReserva = new HttpRequestMessage(HttpMethod.Post,
                apiPath + "Reservas/");

            var aloj = HttpContext.Session.GetString("alojamento").AsInt();

            var requestAlojamento = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Alojamentos/" + aloj);

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var token = HttpContext.Session.GetString("token");
            client.DefaultRequestHeaders.Add("Token", token);

            var responseA = await client.SendAsync(requestAlojamento);

            var alojamento = new Alojamento();

            if (responseA.IsSuccessStatusCode)
            {
                using var stream = await responseA.Content.ReadAsStreamAsync();
                alojamento = await JsonSerializer.DeserializeAsync<Alojamento>
                    (stream, new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true });
            }

            var cliente = HttpContext.Session.GetString("clienteId").AsInt();
            var precoNoite = alojamento.PrecoNoite * (reserva.DataFim.DayOfYear - reserva.DataInicio.DayOfYear);

            var novaReserva = new Reserva()
            {
                ClienteId = cliente,
                AlojamentoId = aloj,
                MetodoPagamentoId = reserva.MetodoPagamentoId,
                EstadoReservaId = 1,
                DataInicio = reserva.DataInicio,
                DataFim = reserva.DataFim,
                PrecoTotal = precoNoite,
                Pagamento = 0
            };

            requestPostReserva.Content = new StringContent(
                JsonSerializer.Serialize(novaReserva, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true}), 
                Encoding.UTF8, "application/json");

            var response = await client.PostAsJsonAsync(
                apiPath + "Reservas/", novaReserva);
            response.EnsureSuccessStatusCode();

            ViewBag.UserType = HttpContext.Session.GetString("userType");
            HttpContext.Session.SetString("alojamento", null);

            return Redirect("/Reservas/Index");
        }
    }
}
