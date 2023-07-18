using Microsoft.AspNetCore.Mvc;
using MVP.Infra.Context;

namespace MVP.Server.Controllers.Generics
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelpDeskControllerBase : ControllerBase
    {
        protected HelpDeskContext HelpDeskContext { get; }

        public HelpDeskControllerBase(HelpDeskContext helpDeskContext) 
        {
            HelpDeskContext = helpDeskContext;
        }
    }
}
