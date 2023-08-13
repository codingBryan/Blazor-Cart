namespace server.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<ProductDto> ConvertToDto(this IEnumerable<Product> products,IEnumerable<Category> categories ){
            return (from product in products join productCategory in categories on product.CategoryId equals productCategory.Id select 
                    new ProductDto
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        ImageURL = product.ImageURL,
                        Price = product.Price,
                        Quantity = product.Quantity,
                        CategoryId = product.CategoryId,
                        CategoryName = productCategory.Name,

                    }).ToList();
        }

        
    }

}