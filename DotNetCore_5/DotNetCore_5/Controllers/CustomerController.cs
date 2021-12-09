using DotNetCore_5.Data;
using DotNetCore_5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Customer> listOfCategory = _context.Customers.Select(e => new Customer
            {
                ProductId = e.ProductId,
                Product = e.Product,
                CustomerName=e.CustomerName,
                Quantity=e.Quantity,
                Price=e.Price,
                ContactNumber=e.ContactNumber
                
            }).ToList();
            //return ;

            //List<Customer> cust;
            //cust = _context.Customers.ToList();
            return View(listOfCategory);
        }
        public IActionResult Create()
        {
            ViewBag.Products = _context.Products;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
