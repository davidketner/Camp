using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camp.Data;
using Camp.Data.Entity;
using Camp.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Camp.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public class DietController : BaseController
    {
        public DietController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {

        }

        [Route("Administrace/Strava")]
        public IActionResult Index()
        {
            return View(Svc.Diets.Items.Include(x => x.UserCreated).Include(x => x.UserUpdated));
        }

        [Route("Administrace/Strava/Vytvorit")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Administrace/Strava/Vytvorit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Diet model)
        {
            if (ModelState.IsValid)
            {
                Svc.CreateDiet(model, User.GetUserId());
                Svc.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Route("Administrace/Strava/Upravit/{id:int}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = Svc.Diets.FindById(id);
            if (model == null)
                return NotFound();
            
            return View(model);
        }

        [Route("Administrace/Strava/Upravit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Diet model)
        {
            if (ModelState.IsValid)
            {
                model.UserUpdatedId = User.GetUserId();
                Svc.Diets.Update(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = Svc.Diets.FindById(id);
            if (model == null)
                return NotFound();

            model.UserDeletedId = User.GetUserId();
            Svc.Diets.Delete(model);
            Svc.Commit();

            return RedirectToAction("Index");
        }
    }
}