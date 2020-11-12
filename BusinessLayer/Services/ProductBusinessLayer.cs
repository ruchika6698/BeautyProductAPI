using BusinessLayer.Interface;
using CommanLayer;
using RepositoryLayer.Interafce;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class ProductBusinessLayer : IProductBusinessLayer
    {
        /// <summary>
        /// Created the Reference of IproductRepository
        /// </summary>
        private readonly IProductRepositoryLayer productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="productRepository"/> class.
        /// </summary>
        /// <param name="productRepository">It contains the object IproductRepository</param>
        public ProductBusinessLayer(IProductRepositoryLayer productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductResponse AddProduct(ProductRequestModel product)
        {
            try
            {
                // Call the AddProduct Method of Books Repository Class
                var response = this.productRepository.AddProduct(product);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///  API for Delete data
        /// </summary>
        /// <param name="Id">Delete data</param>
        /// <returns></returns>
        public ProductModel DeleteProduct(int Id)
        {
            try
            {
                return this.productRepository.DeleteProduct(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all details
        /// </summary>
        public IEnumerable<ProductModel> GetAllProduct()
        {
            try
            {
                return this.productRepository.GetAllProduct();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ProductResponse UpdateProductDetails(int Id, ProductRequestModel updateproductModel)
        {
            try
            {
                // Call the AddBook Method of Books Repository Class
                var response = this.productRepository.UpdateProductDetails(Id, updateproductModel);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
    }
}
