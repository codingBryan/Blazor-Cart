using server.entities.models;

namespace server.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetItems();
        Task<IEnumerable<Category>> GetCategories();
        Task<Product> GetItem(int id);
        Task<Category> GetCategory(int id);
    }
}