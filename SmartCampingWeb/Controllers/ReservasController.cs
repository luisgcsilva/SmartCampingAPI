using Microsoft.AspNetCore.Mvc;
using SmartCampingWeb.Models;
using System.Net.Http.Headers;
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
            if(HttpContext.Session.GetString("userType") == "1")
            {
                var user = HttpContext.Session.GetString("userId").AsInt();
                var requestReservas = new HttpRequestMessage(HttpMethod.Get , 
                    apiPath + "Clientes/" + user + "/reservas");

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

                return View(listReservas);
            }
            return View();
        }
    }
}
