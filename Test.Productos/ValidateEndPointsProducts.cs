using Microsoft.AspNetCore.Mvc;
using Productos.Controllers;
using Productos.Entities;

namespace Test.Productos
{
    public class ValidateEndPointsProducts
    {
        [Fact]
        public void GetProductListOk()
        {
            var productController = new ProductController();
            var result = productController.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetProductByIdOk()
        {
            var productController = new ProductController();
            var result = productController.Get(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetProductByIdNotFound()
        {
            var productController = new ProductController();
            var result = productController.Get(99);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void AddProductOk()
        {
            var productController = new ProductController();
            var product = new EProduct
            {
                Nombre = "rollo cinta",
                Peso = "30 gramos unidad",
                Cantidad = 6
            };
            var result = productController.Post(product);
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public void AddProductBadRequest()
        {
            var productController = new ProductController();
            var product = new EProduct
            {
                Nombre = "Bombillo",
                Peso = "30 gramos unidad",
                Cantidad = 6
            };
            var result = productController.Post(product);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void UpdateProductOk()
        {
            var productController = new ProductController();
            var id = 1;
            var product = new EProduct
            {
                Id = id,
                Nombre = "Bombillo",
                Peso = "40 gramos unidad",
                Cantidad = 5
            };
            var result = productController.Put(id, product);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UpdateProductNotFound()
        {
            var productController = new ProductController();
            var id = 99;
            var product = new EProduct
            {
                Id = id,
                Nombre = "Bombillo",
                Peso = "40 gramos unidad",
                Cantidad = 5
            };
            var result = productController.Put(id, product);
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public void DeleteProductOk()
        {
            var productController = new ProductController();
            var id = 4;
            var result = productController.Delete(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DeleteProductNotFound()
        {
            var productController = new ProductController();
            var id = 99;
            var result = productController.Delete(id);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}