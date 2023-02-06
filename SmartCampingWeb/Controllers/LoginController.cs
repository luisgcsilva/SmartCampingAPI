using Microsoft.AspNetCore.Mvc;
using SmartCamping.Models;
using SmartCampingWeb.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web.Helpers;

namespace SmartCampingWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string apiPath = "https://localhost:7048/smartcamping/";

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            var error = HttpContext.Session.GetString("loginError");
            if (error != null)
            {
                HttpContext.Session.Clear();
                ViewBag.Error = true;
            }
            return View();
        }

        public IActionResult Register()
        {
            var emailError = HttpContext.Session.GetString("registerEmailError");
            var passwordError = HttpContext.Session.GetString("registerPasswordError");
            if (emailError != null)
            {
                HttpContext.Session.Clear();
                ViewBag.EmailError = true;
            }
            if (passwordError != null)
            {
                HttpContext.Session.Clear();
                ViewBag.PasswordError = true;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckRegister(IFormCollection values)
        {
            var email = values["email"].ToString();
            var password = values["password"].ToString();
            var confirmPassword = values["confirmPassword"].ToString();

            if (password.Equals(confirmPassword))
            {
                var utilizador = new Utilizador()
                {
                    TipoUtilizadorId = 1,
                    Email = email,
                    PalavraPasse = Crypto.HashPassword(password)
                };

                var requestPostUtilizador = new HttpRequestMessage(HttpMethod.Post,
                    apiPath + "Utilizadores");

                requestPostUtilizador.Content = new StringContent(
                    JsonSerializer.Serialize(utilizador,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                    Encoding.UTF8, "application/json");

                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Accept.Add(new 
                    MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(
                    apiPath + "Utilizadores/", utilizador);

                response.EnsureSuccessStatusCode();

                return Redirect("/Login/Index");
            }

            return Redirect("/Login/Register");
        }

        [HttpPost]
        public async Task<IActionResult> Login(IFormCollection values)
        {
            var email = values["email"].ToString();
            var password = values["password"].ToString();

            var requestUtilizadores = new HttpRequestMessage(HttpMethod.Get,
                apiPath + "Utilizadores");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.SendAsync(requestUtilizadores);

            if (response.IsSuccessStatusCode) 
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var utilizadores = await JsonSerializer.DeserializeAsync<List<Utilizador>>
                    (responseStream, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                var user = new Utilizador();

                foreach (var utilizador in utilizadores)
                {
                    if (utilizador.Email == email)
                    {
                        user.Email = utilizador.Email;
                        user.PalavraPasse = utilizador.PalavraPasse;
                        user.UtilizadorId = utilizador.UtilizadorId;
                        user.TipoUtilizadorId = utilizador.TipoUtilizadorId;
                    }
                }

                if (user != null && Crypto.VerifyHashedPassword(user.PalavraPasse, password))
                {
                    var requestToken = new HttpRequestMessage(HttpMethod.Get,
                        apiPath + "Token");

                    var client2 = _httpClientFactory.CreateClient();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var response2 = await client2.SendAsync(requestToken);
                    if (response2.IsSuccessStatusCode)
                    {
                        using var responseStream2 = await response2.Content.ReadAsStreamAsync();
                        var token = await JsonSerializer.DeserializeAsync
                            <Token>(responseStream2, new JsonSerializerOptions 
                            { PropertyNameCaseInsensitive = true });
                        HttpContext.Session.SetString("token", token.Value.ToString());
                        HttpContext.Session.SetString("tokenExpiration", token.ExpirationDate.ToString());
                    }
                    else
                    {
                        return Redirect("/");
                    }

                    ViewBag.UserType = user.TipoUtilizadorId.ToString();
                    HttpContext.Session.SetString("userId", user.UtilizadorId.ToString());

                    if (user.TipoUtilizadorId == 1)
                    {
                        var requestCliente = new HttpRequestMessage(HttpMethod.Get,
                            apiPath + "Clientes/utilizador/" + user.UtilizadorId);

                        var token = HttpContext.Session.GetString("token");
                        client.DefaultRequestHeaders.Add("Token", token);

                        var responseCliente = await client.SendAsync(requestCliente);

                        if(responseCliente.IsSuccessStatusCode)
                        {
                            using var stream = await responseCliente.Content.ReadAsStreamAsync();
                            var cliente = await JsonSerializer.DeserializeAsync
                                <Cliente>(stream, new JsonSerializerOptions
                                { PropertyNameCaseInsensitive = true});

                            HttpContext.Session.SetString("clienteId", cliente.ClienteId.ToString());
                        }
                    }

                    HttpContext.Session.SetString("userType", user.TipoUtilizadorId.ToString());
                    return Redirect("/Home/Index");
                }
            }

            HttpContext.Session.SetString("loginError", "Login Error");
            return Redirect("/Login/Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            ViewBag.UserType = null;
            return Redirect("/");
        }
    }
}
