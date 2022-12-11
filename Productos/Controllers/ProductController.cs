using Microsoft.AspNetCore.Mvc;
using Productos.Entities;
using Productos.Functions;

namespace Productos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly Product oProduct;

        public ProductController()
        {
            oProduct = new Product();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(oProduct.GetProducts());
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = oProduct.GetProduct(id);
                return product.Id == 0 ? NotFound("Producto no encontrado") : Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(EProduct product)
        {
            try
            {
                var productAdd = oProduct.AddProduct(product);
                return productAdd.Id == 0 ? BadRequest("El producto ya existe") : Created($"{Request.Path}/{productAdd.Id}", product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EProduct product)
        {
            try
            {
                var idProduct = oProduct.UpdateProduct(id, product);
                return idProduct == 0 ? NotFound("Producto no encontrado o parametro no permitido") : Ok(product);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return oProduct.DeleteProduct(id) ? Ok("Producto eliminado") : NotFound("Producto no eliminado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
