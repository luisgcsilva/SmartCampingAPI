using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartCampingAPIv2.Models;

namespace SmartCampingAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilizadorController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UtilizadorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("register")]
        public string Register(Utilizador utilizador)
        {


            return "";
        }
    }
}
