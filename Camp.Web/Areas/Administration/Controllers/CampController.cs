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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Camp.Web.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public class CampController : BaseController
    {

        public CampController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {

        }

        [Route("Administrace/Tabory")]
        public IActionResult Index()
        {
            return View(Svc.Camps.Items.Include(x => x.CampCategory).Include(x => x.UserCreated).Include(x => x.UserUpdated));
        }

        [Route("Administrace/Tabory/Vytvorit")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Svc.CampCategories.Items, "Id", "Name");
            return View();
        }

        [Route("Administrace/Tabory/Vytvorit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Data.Entity.Camp model)
        {
            if (ModelState.IsValid)
            {
                Svc.CreateCamp(model, User.GetUserId());
                Svc.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(Svc.CampCategories.Items, "Id", "Name", model.CampCategoryId);
            return View(model);
        }

        [Route("Administrace/Tabory/Upravit/{id:int}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = Svc.Camps.FindById(id);
            if (model == null)
                return NotFound();

            ViewBag.Categories = new SelectList(Svc.CampCategories.Items, "Id", "Name", model.CampCategoryId);
            return View(model);
        }

        [Route("Administrace/Tabory/Upravit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Data.Entity.Camp model)
        {
            if (ModelState.IsValid)
            {
                model.UserUpdatedId = User.GetUserId();
                Svc.Camps.Update(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(Svc.CampCategories.Items, "Id", "Name", model.CampCategoryId);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = Svc.Camps.FindById(id);
            if (model == null)
                return NotFound();

            model.UserDeletedId = User.GetUserId();
            Svc.Camps.Delete(model);
            Svc.Commit();

            return RedirectToAction("Index");
        }
    }
}