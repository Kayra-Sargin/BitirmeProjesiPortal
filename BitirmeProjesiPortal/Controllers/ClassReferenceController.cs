using BitirmeProjesiPortal.Entities;
using BitirmeProjesiPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BitirmeProjesiPortal.Controllers
{
    public class ClassReferenceController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ClassReferenceController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            var user = _context.UserAccounts.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null) return Unauthorized();

            ViewBag.UserId = user.Id;

            var classes = _context.ClassReferences
                                  .Include(x => x.Classes)
                                  .Where(x => x.UserId == user.Id)
                                  .OrderByDescending(x => x.Id)
                                  .ToList();
            return View(classes);
        }

        public IActionResult Create(int userId)
        {
            if (_context.Classes != null)
                ViewBag.ClassList = _context.Classes.ToList();
            var model = new ClassReference { UserId = userId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClassReference classReference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classReference);

                try
                {
                    _context.SaveChanges();
                    TempData["Success"] = $"{classReference.CRN} sınıfı başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Index), new { userId = classReference.UserId });
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Sınıf veritabanına kaydedilemedi.");
                }
            }

            ViewBag.ClassList = _context.Classes.ToList();
            return View(classReference);
        }

        public IActionResult Edit(int id)
        {
            var classReference = _context?.ClassReferences?.Find(id);
            if (classReference == null)
            {
                return NotFound();
            }
            return View(classReference);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClassReference classReference)
        {
            if (id != classReference.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classReference);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index), new { userId = classReference.UserId });
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Güncelleme sırasında hata oluştu.");
                }
            }
            return View(classReference);
        }

        public void Delete(int id)
        {
            var classReference = _context.ClassReferences.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(classReference);  
            _context.SaveChanges();
        }
    }
}
