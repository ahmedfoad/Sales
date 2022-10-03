using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         public Task<Product> GetProductByIdAsync(int Id);
         public Task<IReadOnlyList<Product>> GetAllProductsAsync();
         Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
         Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
}
}