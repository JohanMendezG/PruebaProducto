using Productos.Entities;

namespace Productos.Interfaces
{
    public interface IProductDB
    {
        public List<EProduct> GetProducts();
        public EProduct GetProduct(int id);
        public EProduct AddProduct(EProduct product);
        public int UpdateProduct(EProduct product);
        public bool DeleteProduct(int id);
    }
}
