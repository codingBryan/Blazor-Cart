using server.Data;
using server.entities.models;
using Microsoft.EntityFrameworkCore;

namespace server.Repositories.ProductRepo
{
    public class ProductRepository:IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext _context)
        {
            this.context=_context;
        }
        public async Task<IEnumerable<Product>> GetItems(){
            var products = await this.context.products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Category>> GetCategories(){
            var categories = await this.context.categories.ToListAsync();
            return categories;
        }
        
        public async Task<Product> GetItem(int id){
            throw new NotImplementedException();
        }

        public async Task<Category> GetCategory(int id){
            throw new NotImplementedException();
        }
    }
}