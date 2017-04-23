using CSF.Domain;
using CSF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSF.Web.Controllers
{
    public class BlogController : BaseController<Blog>
    {
        public BlogController(BaseManager<Blog> blogManager) : base(blogManager)
        {

        }
    }
}
