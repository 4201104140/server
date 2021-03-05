using Microsoft.AspNetCore.Mvc;

namespace Grand.Web.Controllers
{
    public partial class HomeController : BasePublicController
    {
        [Route("/")]
        public virtual IActionResult Index() => View();
    }
}
