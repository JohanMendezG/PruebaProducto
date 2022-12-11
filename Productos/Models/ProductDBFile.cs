using Productos.Entities;
using Productos.Interfaces;
using Productos.Utilities;

namespace Productos.Models
{
    public class ProductDBFile : IProductDB
    {
        private readonly string fileName;
        private readonly string dataOnFile;

        public ProductDBFile()
        {
            fileName = "FileProducts.txt";
            if (File.Exists(fileName))
            {
                dataOnFile = File.ReadAllText(fileName);
            }
            else
            {
                var data = CreateProductoEjemplo();
                var dataJson = Json.Serialize(data);
                File.WriteAllText(fileName, dataJson);
                dataOnFile = dataJson;
            }
        }

        public EProduct AddProduct(EProduct product)
        {
            try
            {
                var productsOnFile = (List<EProduct>?)Json.Deserealize<List<EProduct>>(dataOnFile);
                if (productsOnFile != null)
                {
                    var productName = productsOnFile.Where(x => x.Nombre == product.Nombre).FirstOrDefault();
                    if (productName == null)
                    {
                        var id = productsOnFile.Max(x => x.Id);
                        product.Id = id + 1;
                        productsOnFile.Add(product);
                    }
                    else
                    {
                        product.Id = 0;
                    }
                }
                else
                {
                    product.Id = 1;
                    productsOnFile = new List<EProduct>
                        {
                            new EProduct
                            {
                                Id= product.Id,
                                Nombre= product.Nombre,
                                Cantidad= product.Cantidad,
                                Peso = product.Peso
                            }
                        };
                }
                File.WriteAllText(fileName, Json.Serialize(productsOnFile));

                return product;
            }
            catch (Exception ex)
            {
                throw new(ex.Message, ex);
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var productsOnFile = (List<EProduct>?)Json.Deserealize<List<EProduct>>(dataOnFile);
                if (productsOnFile != null)
                {
                    var productOnFile = productsOnFile.Where(x => x.Id == id).FirstOrDefault();
                    if (productOnFile != null)
                    {
                        var index = productsOnFile.IndexOf(productOnFile);
                        productsOnFile.RemoveAt(index);
                        File.WriteAllText(fileName, Json.Serialize(productsOnFile));

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new(ex.Message, ex);
            }
        }

        public EProduct GetProduct(int id)
        {
            try
            {
                if (ExistData())
                {
                    var productsOnFile = (List<EProduct>?)Json.Deserealize<List<EProduct>>(dataOnFile);
                    if (productsOnFile != null)
                    {
                        var product = productsOnFile.Where(x => x.Id == id).Select(x => x).FirstOrDefault();
                        return product ?? new EProduct();
                    }
                }

                return new EProduct();
            }
            catch (Exception ex)
            {
                throw new(ex.Message, ex);
            }
        }

        public List<EProduct> GetProducts()
        {
            try
            {
                if (ExistData())
                {
                    var productsOnFile = Json.Deserealize<List<EProduct>>(dataOnFile);
                    return productsOnFile ?? new List<EProduct>();
                }

                return new List<EProduct>();
            }
            catch (Exception ex)
            {
                throw new(ex.Message, ex);
            }
        }

        public int UpdateProduct(EProduct product)
        {
            try
            {
                var productsOnFile = (List<EProduct>?)Json.Deserealize<List<EProduct>>(dataOnFile);
                if (productsOnFile != null)
                {
                    var productOnFile = productsOnFile.Where(x => x.Id == product.Id).FirstOrDefault();
                    if (productOnFile != null)
                    {
                        var productName = productsOnFile.Where(x => x.Nombre == product.Nombre && x.Id != product.Id).FirstOrDefault();
                        if (productName == null)
                        {
                            var index = productsOnFile.IndexOf(productOnFile);
                            productsOnFile[index].Nombre = product.Nombre;
                            productsOnFile[index].Peso = product.Peso;
                            productsOnFile[index].Cantidad = product.Cantidad;
                            File.WriteAllText(fileName, Json.Serialize(productsOnFile));

                            return product.Id;
                        }
                    }
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new(ex.Message, ex);
            }
        }

        private bool ExistData()
        {
            if (string.IsNullOrEmpty(dataOnFile))
                return false;

            return true;
        }

        private static List<EProduct> CreateProductoEjemplo()
        {
            return new List<EProduct>
            {
                new EProduct
                {
                    Id = 1,
                    Nombre = "Bombillo",
                    Peso = "20 gramos unidad",
                    Cantidad = 2
                },
                new EProduct
                {
                    Id = 2,
                    Nombre = "Ladrillos",
                    Peso = "300 gramos unidad",
                    Cantidad = 100
                },
                new EProduct
                {
                    Id = 3,
                    Nombre = "Cemento",
                    Peso = "25 kilos bulto",
                    Cantidad = 20
                }
            };
        }
    }
}
