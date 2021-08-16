using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //gets replaced with whatever the controller classname is
    public class BaseApiController : ControllerBase
    {
    }
}
