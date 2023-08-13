namespace server.Repositories.ProductRepo
{
    public class ProductRepository:IProductRepository
    {
        private readonly DataContext context;
        private IMapper _mapper;

        public ProductRepository(DataContext _context,IMapper _mapper)
        {
            this.context=_context;
            this._mapper=_mapper;
        }
        public async Task<IEnumerable<Product>> GetItems(){
            IEnumerable<Product>? products = await this.context.products.ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Category>> GetCategories(){
            IEnumerable<Category>? categories = await this.context.categories.ToListAsync();
            return categories;
        }
        
        public async Task<Product> GetItem(int id){
            Product? product = await this.context.products.Where(p=>p.Id == id).SingleOrDefaultAsync();
            return product;
        }

        public async Task<Category> GetCategory(int id){
            Category? category = await this.context.categories.Where(c=>c.Id == id).SingleOrDefaultAsync();
            return category;
        }
    }
}