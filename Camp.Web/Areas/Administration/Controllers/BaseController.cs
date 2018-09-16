using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camp.Data;
using Camp.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Camp.Web.Areas.Administration.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ICampService Svc;
        public BaseController(ICampService svc, UserManager<User> userManager)
        {
            Svc = svc;
            Svc.UserManager = userManager;
        }
    }
}