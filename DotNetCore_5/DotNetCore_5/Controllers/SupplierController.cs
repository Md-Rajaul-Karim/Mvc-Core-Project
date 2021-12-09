using DotNetCore_5.Data;
using DotNetCore_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Controllers
{
   
    public class SupplierController : Controller
    {
        ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Supplier> applicants;
            applicants = _context.Suppliers.ToList();
            return View(applicants);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supplier obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
