using GeekShopping.ProductApi.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.ProductApi.Model
{
    [Table("TB_PRODUCT")]
    public class Product : BaseEntity
    {
        [Column("DESCRIPTION")]
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [Column("PRICE")]
        [Required]
        public double Price{ get; set; }
        
        [Column("SIZE")]
        public string Size { get; set; }

        [Column("CATEGORY")]
        public string Category { get; set; }

        [Column("IMAGE_URL")]
        public string ImageUrl { get; set; }
    }
}