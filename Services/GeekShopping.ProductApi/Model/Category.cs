using GeekShopping.Api.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Api.Model;

[Table("TB_CATEGORY")]
public class Category : BaseEntity
{
    [Column("NAME")]
    [Required]
    [StringLength(200)]
    public string? Name { get; set; }

    [Column("PRODUCTS")]
    [Required]
    [StringLength(200)]
    public IEnumerable<Product> Produts { get; set; }

}
