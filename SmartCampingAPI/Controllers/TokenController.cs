using Microsoft.AspNetCore.Mvc;
using SmartCamping.Models;

namespace SmartCampingAPI.Controllers
{
    [Route("smartcamping/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private ITokenManager _tokenManager;

        public TokenController(ITokenManager tokenManager)
        {
            _tokenManager = tokenManager;
        }

        public IActionResult GetToken()
        {
            return Ok(_tokenManager.GenerateToken());
        }
    }
}
