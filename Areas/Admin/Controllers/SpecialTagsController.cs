using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSuperShop.Data;
using OnlineSuperShop.Models;

namespace OnlineSuperShop.Areas.Admin.Controllers
{
    public class SpecialTagsController : Controller
    {
        [Area("Admin")]

        public class SpecialTagController : Controller
        {
            private ApplicationDbContext _db;

            public SpecialTagController(ApplicationDbContext db)
            {
                _db = db;
            }
            public IActionResult Index()
            {
                // var data = db.ProductTypes.ToList();
                return View(_db.SpecialTags.ToList());
            }
            //Create Get Action Method

            public ActionResult Create()
            {
                return View();
            }

            //Create Post Action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(SpecialTag specialTags)
            {
                if (ModelState.IsValid)
                {
                    _db.SpecialTags.Add(specialTags);
                    await _db.SaveChangesAsync();
                    TempData["save"] = "Special Tags has been saved";
                    return RedirectToAction(actionName: nameof(Index));
                }
                return View(specialTags);

            }


            // Edit Action Method
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var specialTag = _db.SpecialTags.Find(id);
                if (specialTag == null)
                {
                    return NotFound();
                }
                return View(specialTag);
            }

            // Post Edit Action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(SpecialTag specialTags)
            {
                if (ModelState.IsValid)
                {
                    _db.Update(specialTags);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(specialTags);

            }


            // Get Details Action Method
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var specialTag = _db.SpecialTags.Find(id);
                if (specialTag == null)
                {
                    return NotFound();
                }
                return View(specialTag);
            }

            // Post Details Action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Details(SpecialTag specialTags)
            {
                return RedirectToAction(nameof(Index));
            }



            // Delete Action Method
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }
                var specialTag = _db.SpecialTags.Find(id);
                if (specialTag == null)
                {
                    return NotFound();
                }
                return View(specialTag);
            }

            // Post Delete Action Method
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int? id, SpecialTag specialTags)
            {
                if (id == null)
                {
                    return NotFound();
                }
                if (id != specialTags.Id)
                {
                    return NotFound();

                }
                var specialTag = _db.SpecialTags.Find(id);
                if (specialTag == null)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    _db.Remove(specialTag);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(specialTags);
            }
        }
    }


}