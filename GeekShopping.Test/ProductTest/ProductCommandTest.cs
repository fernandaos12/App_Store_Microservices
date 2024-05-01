using GeekShopping.ProductApi.Data.ValueObject;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeekShopping.Test.ProductTest
{
    public class ProductCommandTest : IProductRepository
    {
        private readonly List<ProductVO> _products;
        public ProductCommandTest()
        {
            _products = new List<ProductVO>()
            {
                new ProductVO(){Id = 10, Description="Blusa Gamer", Category="Vestuario", Name="Blusa Gamer", Price=230.30, Size="GG", ImageUrl="teste"},
                new ProductVO(){Id = 2, Description="Caneca Mario Gamer", Category="Canecas", Name="Caneca Mario Gamer", Price=50, Size="U", ImageUrl="teste"}
            };
        }

        public Task<ProductVO> Create(ProductVO productvo)
        {
            productvo.Id = GeraId();
            _products.Add(productvo);
            return Task.FromResult(productvo);
        }

        public Task<bool> Delete(long id)
        {
            var item = _products.Where(p => p.Id == id).FirstOrDefault();
            _products.Remove(item);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<ProductVO>> FindAll()
        {
            var itens = _products.Where(p => p.Id > 0);
            return Task.FromResult(itens);
        }

        public Task<ProductVO> FindById(long id)
        {
            var item = _products.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(item);
        }

        public Task<ProductVO> Update(ProductVO productvo)
        {
            productvo.Id = GeraId();
            _products.Add(productvo);
            return Task.FromResult(productvo);
        }

        static long GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }

}
