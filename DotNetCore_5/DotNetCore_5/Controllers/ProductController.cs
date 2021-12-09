using DotNetCore_5.Data;
using DotNetCore_5.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
using static DotNetCore_5.Repositories.AllInterFaces;

namespace DotNetCore_5.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;
        IProductRepository _iProductRepository;
        ICategoryRepository _iCategoryRepository;
        ApplicationDbContext _context;
        public ProductController(IWebHostEnvironment iWebHostEnvironment, IProductRepository iProductRepository, ICategoryRepository iCategoryRepository,
             ApplicationDbContext context)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
            _iProductRepository = iProductRepository;
            _iCategoryRepository = iCategoryRepository;
            _context = context;
        }

        public IActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? page)
        {
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            ViewBag.CurrentFilter = SearchString;
            IEnumerable<ProductViewModel> list = _iProductRepository.GetAllPrduct();
            if (!string.IsNullOrEmpty(SearchString))
            {
                list = list.Where(e => e.ProductName.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(e => e.ProductName).ToList();
                    break;
                default:
                    list = list.OrderBy(e => e.ProductName).ToList();
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _iCategoryRepository.GetAll();
            ViewBag.Suppliers = _context.Suppliers;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false;
            if (ModelState.IsValid)
            {
                if (objModel.Photo != null)
                {
                    string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/product_images");
                    uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueImageName);
                    objModel.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    objModel.ImageName = uniqueImageName;
                }
                _iProductRepository.SaveProduct(objModel);
                result = true;

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
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _iCategoryRepository.GetAll();
            ViewBag.Suppliers = _context.Suppliers;
            ProductViewModel product = _iProductRepository.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel objModel)
        {
            string uniqueImageName = null;
            bool result = false;
            if (objModel.ProductId > 0)
            {
                IEnumerable<ProductViewModel> productAll = _iProductRepository.GetAllPrduct();
                foreach (var item in productAll)
                {
                    if (item.Email == objModel.Email)
                    {
                        ProductViewModel product = _iProductRepository.GetProductById(objModel.ProductId);
                        if (product.Email == objModel.Email)
                        {
                            ModelState.Remove("Email");
                            break;
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "Email is already Used");
                            break;
                        }
                    }

                }
            }

            if (ModelState.IsValid)
            {
                if (objModel.ProductId > 0)
                {
                    if (objModel.Photo != null)
                    {
                        string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/product_images");
                        DeleteExistingImage(Path.Combine(uploadFolder, objModel.ImageName));
                        uniqueImageName = Guid.NewGuid().ToString() + "_" + objModel.Photo.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueImageName);
                        FileStream fileStream = new FileStream(filePath, FileMode.Create);
                        objModel.Photo.CopyTo(fileStream);
                        fileStream.Close();
                        objModel.ImageName = uniqueImageName;
                    }
                    _iProductRepository.UpdateProduct(objModel);
                    result = true;
                }

            }

            if (result)
            {
                return RedirectToAction("Index"/*, new { id = employee.Id }*/);
            }
            else
            {
                ViewBag.Categories = _iCategoryRepository.GetAll();
                ViewBag.Suppliers = _context.Suppliers;
                ProductViewModel product = _iProductRepository.GetProductById(objModel.ProductId);
                return View(product);
            }
        }
        private void DeleteExistingImage(string imagePath)
        {
            FileInfo fileObj = new FileInfo(imagePath);
            if (fileObj.Exists)
            {
                fileObj.Delete();
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Categories = _iCategoryRepository.GetAll();
            ViewBag.Suppliers = _context.Suppliers;
            ProductViewModel product = _iProductRepository.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(ProductViewModel obj)
        {
            if (obj.ImageName != null)
            {
                string uploadFolder = Path.Combine(_iWebHostEnvironment.WebRootPath, "images/product_images");
                DeleteExistingImage(Path.Combine(uploadFolder, obj.ImageName));
            }
            _iProductRepository.DeleteProduct(obj.ProductId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ViewBag.Categories = _iCategoryRepository.GetAll();
            ViewBag.Suppliers = _context.Suppliers;
            ProductViewModel product = _iProductRepository.GetProductById(id);
            return View(product);
        }
        
       
    }
}
