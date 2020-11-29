namespace Pizzeria.Server.Features
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected const string Id = "{id}";
        protected const string PathSeparator = "/";
    }
}
