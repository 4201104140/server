using Grand.Framework.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Grand.Web.Controllers
{
    public abstract partial class BasePublicController : BaseController
    {

        public new IActionResult View(string viewName, object model)
        {
            return base.View(viewName, model);
        }
    }
}
