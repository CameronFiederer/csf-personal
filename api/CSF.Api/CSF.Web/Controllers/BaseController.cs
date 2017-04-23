using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSF.Web.Controllers
{
    [Route("[controller]")]
    public class BaseController
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
