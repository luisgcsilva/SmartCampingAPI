using Microsoft.AspNetCore.Mvc;

namespace SmartCampingWeb.Controllers
{
    public class SessionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private string apiPath = "https://localhost:7048/smartcamping";

        public SessionController(IHttpClientFactory httpClientFactory)
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
               if (email == null)
               {

               }
               else
               {
                    HttpContext.Session.SetString("registerEmailError", "Email Error");
               } 
            }
            else
            {
                HttpContext.Session.SetString("registerPasswordError", "Password Error");
            }
            return Redirect("/Login/Register");
        }

        [HttpPost]
        public async Task<IActionResult> Auth(IFormCollection values)
        {
            var email = values["email"].ToString();
            var password = values["password"].ToString();


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}
