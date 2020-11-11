using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer
{
    public class ProductModel
    {
        /// <summary>
        /// Gets or sets the ProductId
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the ProductName
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Product Brand
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
        /// Gets or sets the CreatedDate
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or set the Image
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Gets or
        ///Get or set the IsDeleted
        /// </summary>
        public string IsDeleted { get; set; }

    }
}
