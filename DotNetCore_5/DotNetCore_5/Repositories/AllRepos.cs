using DotNetCore_5.Data;
using DotNetCore_5.Models;
using DotNetCore_5.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DotNetCore_5.Repositories.AllInterFaces;

namespace DotNetCore_5.Repositories
{
    public class AllRepos
    {
        public class ProductRepository : IProductRepository
        {
            private readonly ApplicationDbContext _context;

            public ProductRepository(ApplicationDbContext context)
            {
                this._context = context;
            }

            public void DeleteProduct(int id)
            {
                Product product = _context.Products.Find(id);
                _context.Products.Remove(product);
                _context.SaveChanges();
            }

            public IEnumerable<ProductViewModel> GetAllPrduct()
            {
                IEnumerable<ProductViewModel> listOfProduct = _context.Products.Select(e => new ProductViewModel
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    CategoryId = e.CategoryId,
                    CategoryName = e.Category.CategoryName,
                    Email = e.Email,
                    PurchaseDate = e.PurchaseDate,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    ImageName = e.ImageName,
                }).ToList();
                return listOfProduct;
            }

           

            public ProductViewModel GetProductById(int id)
            {
                Product e = _context.Products.AsNoTracking().SingleOrDefault(e => e.ProductId == id);
                ProductViewModel product = new ProductViewModel
                {
                    ProductId = e.ProductId,
                    ProductName = e.ProductName,
                    CategoryId = e.CategoryId,
                    SupplierId=e.SupplierId,
                    Email = e.Email,
                    PurchaseDate = e.PurchaseDate,
                    Quantity = e.Quantity,
                    UnitPrice = e.UnitPrice,
                    ImageName = e.ImageName,
                };
                return product;
            }

            public void SaveProduct(ProductViewModel obj)
            {
                Product obj1 = new Product()
                {
                    ProductName = obj.ProductName,
                    CategoryId = obj.CategoryId,
                    SupplierId = obj.SupplierId,
                    Email = obj.Email,
                    PurchaseDate = obj.PurchaseDate,
                    Quantity = obj.Quantity,
                    UnitPrice = obj.UnitPrice,
                    ImageName = obj.ImageName,
                };
                _context.Products.Add(obj1);
                _context.SaveChanges();
            }

            public void UpdateProduct(ProductViewModel Upobj)
            {
                Product obj = new Product();
                obj.ProductId = Upobj.ProductId;
                obj.ProductName = Upobj.ProductName;
                obj.CategoryId = Upobj.CategoryId;
                obj.SupplierId = Upobj.SupplierId;
                obj.Email = Upobj.Email;
                obj.PurchaseDate = Upobj.PurchaseDate;
                obj.Quantity = Upobj.Quantity;
                obj.UnitPrice = Upobj.UnitPrice;
                obj.ImageName = Upobj.ImageName;
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }

        }
        public class CategoryRepository : ICategoryRepository
        {
            private readonly ApplicationDbContext _context;
            public CategoryRepository(ApplicationDbContext context)
            {
                this._context = context;
            }
            public void Delete(int id)
            {
                Category category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                Save();
            }

            public IEnumerable<CategoryViewModel> GetAll()
            {
                IEnumerable<CategoryViewModel> listOfCategory = _context.Categories.Select(e => new CategoryViewModel
                {
                    CategoryId = e.CategoryId,
                    CategoryName = e.CategoryName
                }).ToList();
                return listOfCategory;
            }

            public CategoryViewModel GetById(int id)
            {
                Category c = _context.Categories.SingleOrDefault(e => e.CategoryId == id);
                CategoryViewModel category = new CategoryViewModel
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName

                };
                return category;
            }

            public void Insert(CategoryViewModel objModel)
            {
                Category obj = new Category()
                {
                    CategoryName = objModel.CategoryName
                };
                _context.Categories.Add(obj);
                Save();
            }

            public void Save()
            {
                _context.SaveChanges();
            }

            public void Update(CategoryViewModel objModel)
            {
                Category obj = new Category();
                obj.CategoryId = objModel.CategoryId;
                obj.CategoryName = objModel.CategoryName;
                _context.Entry(obj).State = EntityState.Modified;
                Save();
            }
        }
    }
}
