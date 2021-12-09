using DotNetCore_5.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore_5.Repositories
{
    public class AllInterFaces
    {
        public interface IProductRepository
        {
            IEnumerable<ProductViewModel> GetAllPrduct();
            ProductViewModel GetProductById(int id);
            void SaveProduct(ProductViewModel obj);
            void UpdateProduct(ProductViewModel Upobj);
            void DeleteProduct(int id);
            
        }
        public interface ICategoryRepository
        {
            IEnumerable<CategoryViewModel> GetAll();
            CategoryViewModel GetById(int id);
            void Insert(CategoryViewModel objModel);
            void Update(CategoryViewModel objModel);
            void Delete(int id);
            void Save();

        }
    }
}
