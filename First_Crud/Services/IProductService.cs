using First_Crud.DTOS;
using First_Crud.Modals;

public interface IProductService
{
    IEnumerable<Product> GetProducts();
    ProductResponse GetProductById(int id);
    ProductResponse AddProduct(ProductRequired product);
    ProductResponse UpdateProduct(Product product);
    ProductResponse DeleteProduct(int id);
}