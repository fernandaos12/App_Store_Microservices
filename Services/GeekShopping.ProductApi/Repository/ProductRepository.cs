using AutoMapper;
using GeekShopping.Api.Model;
using GeekShopping.Api.Model.Context;
using GeekShopping.Api.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _context;

        public ProductRepository(MySqlContext context)
        {
            _context = context;
        }
        public async Task<Product> Create(Product p)
        {
            _context.Product.Add(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
                
                if(product == null)
                {
                    return false;
                }
                else
                {
                    _context.Product.Remove(product);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            List<Product> Product = await _context.Product.ToListAsync();
            return Product.ToList();
        }

        public async Task<Product> FindById(long id)
        {
            var product = await _context.Product.Where(p => p.Id == id).FirstOrDefaultAsync();            
            return product;
        }

        public async Task<Product> Update(Product p)
        {
            _context.Product.Update(p);
            await _context.SaveChangesAsync();
            return p;
        }

       
    }
}
