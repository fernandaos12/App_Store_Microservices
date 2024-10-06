using GeekShopping.Api.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Api.Model;

[Table("TB_PRODUCT")]
public class Product : BaseEntity
{
    [Column("DESCRIPTION")]
    [Required]
    [StringLength(200)]
    public string? Description { get; set; }  
    
    [Column("NAME")]
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }

    [Column("PRICE")]
    [Required]
    public double Price{ get; set; }
    
    [Column("SIZE")]
    public string? Size { get; set; }

    [Column("CATEGORY")]
    public Category Category { get; set; }

    [Column("IMAGE_URL")]
    public string? ImageUrl { get; set; }
}