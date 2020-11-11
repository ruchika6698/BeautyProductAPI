using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommanLayer
{
    public class ProductRequestModel
    {
        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        [RegularExpression("^[A-Z][a-zA-Z]{3,15}[ ][A-Z][a-zA-Z]{3,15}*$", ErrorMessage = "Product Name is not valid")]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ProductBrand
        /// </summary>
        [RegularExpression("^[A-Z][a-zA-Z]{3,15}[ ][A-Z][a-zA-Z]{3,15}*$", ErrorMessage = "Product Brand Name is not valid")]
        public string ProductBrand { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        //[RegularExpression("^[A-Z][a-zA-Z]s?[a-zA-Z]*$", ErrorMessage = "Description is not valid")]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Gets or sets the Price
        /// </summary>
        public string Price { get; set; }


        /// <summary>
        /// Gets or sets the Image
        /// </summary>
        public IFormFile Image { get; set; }
    }
}