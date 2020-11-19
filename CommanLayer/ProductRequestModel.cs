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
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ProductBrand
        /// </summary>
        public string ProductBrand { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
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