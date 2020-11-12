using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CommanLayer;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.AppDbContext;
using RepositoryLayer.Interafce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class ProductRepositoryLayer : IProductRepositoryLayer
    {
        /// <summary>
        /// Created the Reference of ApplicationdbContext
        /// </summary>
        private Application dbContext;

        private readonly IConfiguration configuration;

        ProductResponse productResponse = new ProductResponse();

        ProductModel productModel = new ProductModel();

        /// <summary>
        /// Initializes a new instance of the for class
        /// </summary>
        /// <param name="dbContext">It contains the object ApplicationDbContext</param>
        public ProductRepositoryLayer(Application dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public ProductResponse AddProduct(ProductRequestModel product)
        {
            try
            {
                string image = AddImage(product);
                productModel.ProductName = product.ProductName;
                productModel.ProductBrand = product.ProductBrand;
                productModel.ProductDescription = product.ProductDescription;
                productModel.Price = product.Price;
                productModel.CreatedDate = DateTime.Now;
                productModel.Image = image;
                productModel.IsDeleted = "No";
                this.dbContext.ProductDetails.Add(productModel);
                this.dbContext.SaveChanges();
                return Response(productModel);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public ProductResponse Response(ProductModel productModel)
        {
            ProductResponse productResponse = new ProductResponse();
            productResponse.ProductId = productModel.ProductId;
            productResponse.ProductName = productModel.ProductName;
            productResponse.ProductBrand = productModel.ProductBrand;
            productResponse.ProductDescription = productModel.ProductDescription;
            productResponse.Price = productModel.Price;
            productResponse.CreatedDate = productModel.CreatedDate;
            productResponse.Image = productModel.Image;
            return productResponse;
        }

        public string AddImage(ProductRequestModel requestModel)
        {
            Account account = new Account(
                                     configuration["CloudinarySettings:CloudName"],
                                     configuration["CloudinarySettings:ApiKey"],
                                     configuration["CloudinarySettings:ApiSecret"]);
            var path = requestModel.Image.OpenReadStream();
            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(requestModel.Image.FileName, path)
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            return uploadResult.Url.ToString();
        }

        /// <summary>
        /// Method to Add Conversion Detail to Database.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Conversion result</returns>
        public ProductModel DeleteProduct(int Id)
        {
            try
            {
                ProductModel product = dbContext.ProductDetails.Find(Id);
                if (product != null)
                {
                    //Remove Data in database
                    dbContext.ProductDetails.Remove(product);
                    //saves all changes in database
                    dbContext.SaveChanges();
                }
                return product;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method To Get All Product Details.
        /// </summary>
        public IEnumerable<ProductModel> GetAllProduct()
        {
            try
            {
                return dbContext.ProductDetails;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Method To Update Product details
        /// </summary>
        public ProductResponse UpdateProductDetails(int Id, ProductRequestModel updateproductModel)
        {
            try
            {
                var response = this.dbContext.ProductDetails.FirstOrDefault(value => ((value.ProductId == Id)) && ((value.IsDeleted == "No")));

                if (response != null)
                {
                    string image = AddImage(updateproductModel);
                    response.ProductName = updateproductModel.ProductName;
                    response.ProductBrand = updateproductModel.ProductBrand;
                    response.ProductDescription = updateproductModel.ProductDescription;
                    response.Price = updateproductModel.Price;
                    response.Image = image;
                    response.IsDeleted = "No";
                    this.dbContext.ProductDetails.Update(response);
                    this.dbContext.SaveChanges();

                    return Response(response);
                }
                return productResponse;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
