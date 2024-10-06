using GeekShopping.Api.Model;
using GeekShopping.Api.Repository.Interfaces;
using GeekShopping.Api.Model.Context;
using Microsoft.EntityFrameworkCore;
using GeekShopping.Api.Data.ObjectDTO;

namespace GeekShopping.Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MySqlContext _context;
        public CategoryRepository(MySqlContext context)
        {
            _context = context;
        }
        public async Task<Category> Create(Category Category)
        {
            _context.Category.Add(Category);
            await _context.SaveChangesAsync();
            return Category;
        }

        public async Task<bool> Delete(int id)
        {
            var cat = await FindById(id);
            _context.Category.Remove(cat);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Category>> FindAll()
        {
            var retorno = await _context.Category.ToListAsync();
            return retorno;
        }


        public async Task<Category> FindById(long id)
        {
            return await _context.Category.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesProducts()
        {
            return await _context.Category.Include(p => p.Produts).ToListAsync();
        }


        public async Task<Category> Update(Category Category)
        {
            _context.Entry(Category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Category;

        }
    }
}
