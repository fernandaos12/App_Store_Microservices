
using GeekShopping.Api.Model;

namespace GeekShopping.Api.Data.ObjectDTO;

public class CategoryDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<Product> Produts { get; set; }
}
