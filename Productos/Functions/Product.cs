using Productos.Entities;
using Productos.Interfaces;
using Productos.Models;
using Productos.Utilities;

namespace Productos.Functions
{
    public class Product
    {
        private readonly ILog log;
        private readonly IProductDB productoDB;

        public Product()
        {
            log = new Log();
            productoDB = new ProductDBFile();
        }

        public List<EProduct> GetProducts()
        {
            try
            {
                return productoDB.GetProducts();                
            }
            catch (Exception ex)
            {
                log.AddLog($@"{ex.Message} _{ex.StackTrace}");
                throw new Exception("Error al obtener productos");
            }
        }

        public EProduct GetProduct(int id)
        {
            try
            {
                return productoDB.GetProduct(id);                
            }
            catch (Exception ex)
            {
                log.AddLog($@"{ex.Message} _{ex.StackTrace}");
                throw new Exception("Error al obtener producto");
            }
        }

        public EProduct AddProduct(EProduct product)
        {
            try
            {
                return productoDB.AddProduct(product);                
            }
            catch (Exception ex)
            {
                log.AddLog($@"{ex.Message} _{ex.StackTrace}");
                throw new Exception("Error al insertar producto");
            }
        }

        public int UpdateProduct(int id, EProduct product)
        {
            try
            {
                if (product.Id == id)
                {
                    return productoDB.UpdateProduct(product);
                }
                
                return 0;
            }
            catch (Exception ex)
            {
                log.AddLog($@"{ex.Message} _{ex.StackTrace}");
                throw new Exception("Error al insertar producto");
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                return productoDB.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                log.AddLog($@"{ex.Message} _{ex.StackTrace}");
                throw new Exception("Error al insertar producto");
            }
        }
    }
}
