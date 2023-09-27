#region namespaces
using Microsoft.AspNetCore.Mvc;
#endregion

namespace EcommerceAPI.Controller
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
  
    public class BaseController : ControllerBase
    {
    }
}
