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
    public class CampBatchController : BaseController
    {
        public CampBatchController(ICampService svc, UserManager<User> userManager) : base(svc, userManager)
        {

        }

        [Route("Administrace/Turnusy-taboru")]
        public IActionResult Index()
        {
            return View(Svc.CampBatches.Items.Include(x => x.Camp).ThenInclude(x => x.CampCategory));
        }

        [Route("Administrace/Turnusy-taboru/Vytvorit")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Camps = new SelectList(Svc.Camps.Items.OrderBy(x => x.CampCategoryId), "Id", "Name");
            return View();
        }

        [Route("Administrace/Turnusy-taboru/Vytvorit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CampBatch model)
        {
            if (ModelState.IsValid)
            {
                Svc.CreateCampBatch(model, User.GetUserId());
                Svc.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.Camps = new SelectList(Svc.Camps.Items.OrderBy(x => x.CampCategoryId), "Id", "Name", model.CampId);
            return View(model);
        }

        [Route("Administrace/Turnusy-taboru/Upravit/{id:int}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = Svc.CampBatches.FindById(id);
            if (model == null)
                return NotFound();

            ViewBag.Camps = new SelectList(Svc.Camps.Items.OrderBy(x => x.CampCategoryId), "Id", "Name", model.CampId);
            return View(model);
        }

        [Route("Administrace/Turnusy-taboru/Upravit/{id:int}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CampBatch model)
        {
            if (ModelState.IsValid)
            {
                model.UserUpdatedId = User.GetUserId();
                Svc.CampBatches.Update(model);
                Svc.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.Camps = new SelectList(Svc.Camps.Items.OrderBy(x => x.CampCategoryId), "Id", "Name", model.CampId);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var model = Svc.CampBatches.FindById(id);
            if (model == null)
                return NotFound();

            model.UserDeletedId = User.GetUserId();
            Svc.CampBatches.Delete(model);
            Svc.Commit();

            return RedirectToAction("Index");
        }

        [Route("Administrace/Turnusy-taboru/Instruktori/{id:int}")]
        [HttpGet]
        public IActionResult Instructors(int id)
        {
            var model = Svc.CampBatches.Items
                .Include(x => x.InstructorCamps).ThenInclude(x => x.Instructor)
                .Include(x => x.InstructorCamps).ThenInclude(x => x.InstructorRole).FirstOrDefault(x => x.Id == id);
            
            if (model == null)
                return NotFound();

            ViewBag.Instructors = new SelectList(Svc.Instructors.Items.OrderBy(x => x.Lastname).ThenBy(x => x.Firstname), "Id", "Fullname");
            ViewBag.InstructorRoles = new SelectList(Svc.InstructorRoles.Items.OrderBy(x => x.Name), "Id", "Name");
            return View(model);
        }

        [HttpPost, ActionName("DeleteInstructor")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteInstructor(int campBatchId, int instructorId, int instructorRoleId)
        {
            Svc.RemoveInstructorCampBatch(campBatchId, instructorId, instructorRoleId);
            Svc.Commit();

            return RedirectToAction("Instructors", new { @id = campBatchId });
        }

        public JsonResult AddInstructor(int id, int instructorId, int instructorRoleId)
        {
            var res = Svc.AddInstructorToCamp(instructorId, id, instructorRoleId, User.GetUserId());
            if (res.IsOK)
                Svc.Commit();

            return Json(new { res.IsOK, res.Message });
        }
    }
}