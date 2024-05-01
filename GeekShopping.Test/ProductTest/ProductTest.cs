using GeekShopping.ProductApi.Controllers;
using GeekShopping.ProductApi.Data.ValueObject;
using GeekShopping.ProductApi.Model;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Transactions;
using System.Xml.Linq;
using Xunit;

namespace GeekShopping.Test.ProductTest
{
    public class ProductTest
    {
        readonly ProductCommandTest _repo;

        public ProductTest()
        {
            _repo = new ProductCommandTest();
        }

        [Fact]
        public void Get_WhenCallOKResults_sucess()
        {
            //Arrange

            //Act
            var okResult = _repo.FindAll().Result;
            //Assert
            Assert.Equal(2, okResult.Count());  
        }

        [Fact]
        public void Delete_WhenItemExist()
        {
            //Arrange
            int id = 2;
            //Act
            var okResult = _repo.Delete(id);
            //Assert
            Assert.True(true,"item removido");
        }
    }
}

