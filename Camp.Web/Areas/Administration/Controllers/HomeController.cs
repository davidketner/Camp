using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camp.Data;
using Camp.Data.Entity;
using Camp.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Camp.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public class HomeController : BaseController
    {
        public HomeController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {

        }
        
        [Route("Administrace/Prehled")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Administrace")]
        public IActionResult Redirect()
        {
            return RedirectToAction("Index");
        }
    }
}