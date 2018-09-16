using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Camp.Data;
using Camp.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Camp.Web.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Camp.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public class CampCategoryController : BaseController
    {
        public CampCategoryController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {
        }

        [Route("Administrace/Kategorie-taboru")]
        public IActionResult Index()
        {
            return View(Svc.CampCategories.Items.Include(x => x.UserCreated));
        }

        [Route("Administrace/Kategorie-taboru/Vytvorit")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Administrace/Kategorie-taboru/Vytvorit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CampCategory model)
        {
            if (ModelState.IsValid)
            {
                Svc.CreateCampCategory(model, User.GetUserId());
                Svc.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Route("Administrace/Kategorie-taboru/Upravit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var model = Svc.CampCategories.FindById(id);
            if (model == null)
                return NotFound();
            
            return View(model);
        }

        [Route("Administrace/Kategorie-taboru/Upravit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CampCategory model)
        {
            if (ModelState.IsValid)
            {
                model.UserUpdatedId = User.GetUserId();
                Svc.CampCategories.Update(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = Svc.CampCategories.FindById(id);
            if (model == null)
                return NotFound();

            model.UserDeletedId = User.GetUserId();
            Svc.CampCategories.Delete(model);
            Svc.Commit();

            return RedirectToAction("Index");
        }
    }
}