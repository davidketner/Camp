using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camp.Data;
using Microsoft.AspNetCore.Mvc;

namespace Camp.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ICampService Svc;
        public BaseController(ICampService svc)
        {
            Svc = svc;
        }
    }
}