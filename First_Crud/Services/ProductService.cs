using First_Crud.Data;
using First_Crud.DTOS;
using First_Crud.Modals;
using Microsoft.AspNetCore.Http.HttpResults;

namespace First_Crud.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;
        public ProductService(AppDbContext appDbContext)
        {
            context = appDbContext;
        }
        public ProductResponse AddProduct(ProductRequired product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            };

            context.Products.Add(newProduct);
            context.SaveChanges();

            return new ProductResponse
            {
                isSuccess = true,
                isFailure = false,
                value = newProduct
            };
        }

        public ProductResponse DeleteProduct(int id)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return new ProductResponse
                {
                    isSuccess = false,
                    isFailure = true,
                    errors = "Product not found."
                };
            }

            context.Products.Remove(product);
            context.SaveChanges();

            return new ProductResponse
            {
                isSuccess = true,
                isFailure = false,
                value = product
            };
        }

        public ProductResponse GetProductById(int id)
        {
            var product = context.Products.Find(id);

            if (product == null)
            {
                return new ProductResponse
                {
                    isSuccess = false,
                    isFailure = true,
                    errors = "Product not found."
                };
            }

            return new ProductResponse
            {
                isSuccess = true,
                isFailure = false,
                value = product
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            var response = context.Products.ToList();
            return response;
        }

        public ProductResponse UpdateProduct(Product product)
        {
            var existingProduct = context.Products.Find(product.Id);

            if (existingProduct == null)
            {
                return new ProductResponse
                {
                    isSuccess = false,
                    isFailure = true,
                    errors = "Product not found."
                };
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;

            context.SaveChanges();

            return new ProductResponse
            {
                isSuccess = true,
                isFailure = false,
                value = existingProduct
            };
        }
    }
}
