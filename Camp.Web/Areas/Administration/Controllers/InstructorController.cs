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
    public class InstructorController : BaseController
    {
        public InstructorController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {

        }

        [Route("Administrace/Instruktori")]
        public IActionResult Index()
        {
            return View(Svc.Instructors.Items.Include(x => x.UserCreated).Include(x => x.UserUpdated));
        }

        [Route("Administrace/Instruktori/Vytvorit")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Administrace/Instruktori/Vytvorit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Instructor model)
        {
            if (ModelState.IsValid)
            {
                Svc.CreateInstructor(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Route("Administrace/Instruktori/Upravit/{id:int}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = Svc.Instructors.FindById(id);
            if (model == null)
                return NotFound();

            return View(model);
        }

        [Route("Administrace/Instruktori/Upravit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Instructor model)
        {
            if (ModelState.IsValid)
            {
                model.UserUpdatedId = User.GetUserId();
                Svc.Instructors.Update(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = Svc.Instructors.FindById(id);
            if (model == null)
                return NotFound();

            model.UserDeletedId = User.GetUserId();
            Svc.Instructors.Delete(model);
            Svc.Commit();

            return RedirectToAction("Index");
        }
    }
}