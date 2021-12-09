using DotNetCore_5.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DotNetCore_5.Repositories.AllInterFaces;

namespace DotNetCore_5.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository _IcategoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _IcategoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            return View(_IcategoryRepository.GetAll());
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _IcategoryRepository.Insert(obj);
            }
            return PartialView("_CategoryList", _IcategoryRepository.GetAll());
        }
        [HttpGet]
        public PartialViewResult Edit(int id)
        {
            CategoryViewModel obj = _IcategoryRepository.GetById(id);
            ViewBag.Details = "Show";
            return PartialView("~/Views/Category/_Edit.cshtml", obj);
        }
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult PostEdit(CategoryViewModel obj)
        {
            var result = false;
            if (obj.CategoryId > 0)
            {
                if (ModelState.IsValid)
                {
                    _IcategoryRepository.Update(obj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public PartialViewResult Delete(int id)
        {
            CategoryViewModel obj = _IcategoryRepository.GetById(id);
            ViewBag.Details = "Show";
            return PartialView("~/Views/Category/_Delete.cshtml", obj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult PostDelete(CategoryViewModel obj)
        {
            _IcategoryRepository.Delete(obj.CategoryId);
            return RedirectToAction("Index");
        }
    }
}
