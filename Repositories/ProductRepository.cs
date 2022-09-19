using EmporiumRemuneration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmporiumRemuneration.Context;


namespace EmporiumRemuneration.Repositories
{
    public class ProductRepository : IProductInfo
    {
        //private static List<ProductInfo> _productInfo = new List<ProductInfo>() { new ProductInfo { Id = 1000, Name = "Item01", Price = 50, Quantity = 0 }, new ProductInfo { Id = 1001, Name = "Item02", Price = 100, Quantity = 0 }, new ProductInfo { Id = 1002, Name = "Item03", Price = 150, Quantity = 0 } };

        EmporiumContext _productCxt;

        public ProductRepository(EmporiumContext _productDbInfo)
        {
            _productCxt = _productDbInfo;
        }
        public bool AddProduct(ProductInfo _productInfo)
        {
            try
            {

                _productCxt.Products.Add(_productInfo);
                _productCxt.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }

            return true;
        }

        public void DeleteProduct(int Id)
        {
            var delProduct = _productCxt.Products.Where(X=>X.Id == Id).FirstOrDefault();

            _productCxt.Products.Remove(delProduct);
            _productCxt.SaveChanges();

        }

        public ProductInfo EditProduct(ProductInfo productInfo, int Id)
        {
            try
            {
                var editProduct = _productCxt.Products.Where(X => X.Id == Id).FirstOrDefault();
                    editProduct.Name = productInfo.Name;
                    editProduct.Price = productInfo.Price;
                    editProduct.Quantity = productInfo.Quantity;

                _productCxt.SaveChanges();
                return editProduct;

            }
            catch (Exception ex)
            {
                return null;
            }

            //return null;
            
        }

        public ProductInfo GetProductById(int Id)
        {
            return _productCxt.Products.Where(X => X.Id == Id).FirstOrDefault();
        }

        public List<ProductInfo> GetProducts()
        {
            return _productCxt.Products.ToList();
        }
    }
}
