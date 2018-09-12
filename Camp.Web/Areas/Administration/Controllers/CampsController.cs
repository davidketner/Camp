using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camp.Data;
using Microsoft.AspNetCore.Mvc;

namespace Camp.Web.Areas.Administration.Controllers
{
    public class CampsController : Controller
    {
        private readonly ICampService Svc;

        public CampsController(ICampService svc)
        {
            Svc = svc;
        }

        [Area("Administration")]
        [Route("administration/[controller]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}