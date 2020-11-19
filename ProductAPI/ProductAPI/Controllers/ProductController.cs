using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductBusinessLayer ProductBuiseness;

        public ProductController(IProductBusinessLayer ProductBuiseness)
        {
            this.ProductBuiseness = ProductBuiseness;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProduct([FromForm] ProductRequestModel productRequestModel)
        {
            try
            {
                // Call the Add Book Method of Book class
                var response = this.ProductBuiseness.AddProduct(productRequestModel);

                // check if Id is not equal to zero
                if (!response.ProductId.Equals(0))
                {
                    bool success = true;
                    var message = "Product Added Successfully";
                    return this.Ok(new { success, message, data = response });
                }
                else
                {
                    bool success = false;
                    var message = "Failed to add";
                    return this.BadRequest(new { success, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

        /// <summary>
        ///  API for Delete data
        /// </summary>
        /// <param name="Id">Delete data</param>
        /// <returns>delete data by ID</returns>
        [HttpDelete("{Id}")]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteProduct(int Id)
        {
            try
            {
                var result = this.ProductBuiseness.DeleteProduct(Id);
                //if result is not equal to zero then details Deleted sucessfully
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "Data deleted Sucessfully";
                    return this.Ok(new { Success, Message, Data = Id });
                }
                else                                           //Data is not deleted 
                {
                    var Success = "False";
                    var Message = "Data is not deleted Sucessfully";
                    return this.BadRequest(new { Success, Message, Data = Id });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///  API for get all Product details
        /// </summary>
        [HttpGet]
//[Authorize(Roles = "Admin,User")]

        public ActionResult<IEnumerable<ProductModel>> GetAllProduct()
        {
            try
            {
                var result = this.ProductBuiseness.GetAllProduct();
                //if result is not equal to zero then details found
                if (!result.Equals(null))
                {
                    var Success = "True";
                    var Message = "All Data found ";
                    return this.Ok(new { Success, Message, Data = result });
                }
                else                                           //Data is not found
                {
                    var Success = "False";
                    var Message = " Data is not found";
                    return this.BadRequest(new { Success, Message, Data = result });
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        [Route("{Id}")]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProductDetails([FromRoute] int Id, [FromForm] ProductRequestModel updateproductModel)
        {
            try
            {

                // Call the User Add Product Method of productBL classs
                var response = this.ProductBuiseness.UpdateProductDetails(Id, updateproductModel);

                // check if Id is not equal to zero
                if (!response.ProductId.Equals(0))
                {
                    bool status = true;
                    var message = "Product Details Updated Successfully";
                    return this.Ok(new { status, message, data = response });
                }
                else
                {
                    bool status = false;
                    var message = "Product Details Not Found";
                    return this.NotFound(new { status, message });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { status = false, message = e.Message });
            }
        }

    }
}
