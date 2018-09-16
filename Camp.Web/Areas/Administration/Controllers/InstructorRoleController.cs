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
    public class InstructorRoleController : BaseController
    {
        public InstructorRoleController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {

        }

        [Route("Administrace/Role-instruktoru")]
        public IActionResult Index()
        {
            return View(Svc.InstructorRoles.Items.Include(x => x.UserCreated).Include(x => x.UserUpdated));
        }

        [Route("Administrace/Role-instruktoru/Vytvorit")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Administrace/Role-instruktoru/Vytvorit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InstructorRole model)
        {
            if (ModelState.IsValid)
            {
                Svc.CreateInstructorRole(model, User.GetUserId());
                Svc.Commit();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Route("Administrace/Role-instruktoru/Upravit/{id:int}")]
        public IActionResult Edit(int id)
        {
            var model = Svc.InstructorRoles.FindById(id);
            if (model == null)
                return NotFound();
            
            return View(model);
        }

        [Route("Administrace/Role-instruktoru/Upravit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InstructorRole model)
        {
            if (ModelState.IsValid)
            {
                model.UserUpdatedId = User.GetUserId();
                Svc.InstructorRoles.Update(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = Svc.InstructorRoles.FindById(id);
            if (model == null)
                return NotFound();

            model.UserDeletedId = User.GetUserId();
            Svc.InstructorRoles.Delete(model);
            Svc.Commit();

            return RedirectToAction("Index");
        }
    }
}