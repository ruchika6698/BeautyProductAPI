using CommanLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IProductBusinessLayer
    {
        ProductResponse AddProduct(ProductRequestModel product);

        ProductModel DeleteProduct(int Id);
        IEnumerable<ProductModel> GetAllProduct();
        ProductResponse UpdateProductDetails(int Id, ProductRequestModel updateproductModel);

    }
}
