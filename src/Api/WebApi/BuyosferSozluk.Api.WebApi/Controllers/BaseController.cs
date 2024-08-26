using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BuyosferSozluk.Api.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public Guid? UserId
        {
            get
            {
                var str = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return string.IsNullOrEmpty(str) ? Guid.Empty : new Guid(str);

            }
        }
    }
}
