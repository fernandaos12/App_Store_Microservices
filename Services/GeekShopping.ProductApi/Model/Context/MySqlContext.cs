using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductApi.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext()
        {            
        }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {            
        }

        //dotnet ef migrations add-migration AddProductDatatableOnDB
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product{
                    Id = 2,
                    Name = "Mario T-Shirt",
                    Price = 69.90,
                    Description = "Mario T-Shirt",
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE",
                    Category = "R-shirts",
                    Size = "M"
                },
                new Product{
                    Id = 3,
                    Name = "Turtle T-Shirt",
                    Price = 89.90,
                    Description = "Mario T-Shirt",
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE",
                    Category = "R-shirts",
                    Size = "G"
                },
                new Product{
                    Id = 4,
                    Name = "Princesa T-Shirt",
                    Price = 99.90,
                    Description = "Mario T-Shirt",
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE",
                    Category = "R-shirts",
                    Size = "M"
                }, 
                new Product{
                    Id = 5,
                    Name = "Luigi T-Shirt",
                    Price = 169.90,
                    Description = "Mario T-Shirt",
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fboutiquemario.fr%2Fvetement%2Ftshirt%2Fsuper-mario-ds&psig=AOvVaw171sMWTgVHaUIhEiKndWLR&ust=1705000045534000&source=images&cd=vfe&ved=0CBIQjRxqFwoTCNjysqnC04MDFQAAAAAdAAAAABAE",
                    Category = "R-shirts",
                    Size = "GG"
                }
                
                );
                       // base.OnModelCreating(modelBuilder);
        }
    }
}