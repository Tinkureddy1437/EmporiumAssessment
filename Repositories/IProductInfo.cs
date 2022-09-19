using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Models;

namespace EmporiumRemuneration.Repositories
{
    public interface IProductInfo
    {
        public List<ProductInfo> GetProducts();
        public ProductInfo GetProductById(int Id);
        public bool AddProduct(ProductInfo productInfo);
        public ProductInfo EditProduct(ProductInfo productInfo, int Id);
        public void DeleteProduct(int Id);

    }
}
