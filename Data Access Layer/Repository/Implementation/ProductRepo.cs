using Microsoft.EntityFrameworkCore;
using Second.Data_Access_Layer.Repository.Interface;
using Secondzz.Data_Access_Layer.Context;
using Secondzz.Data_Access_Layer.Models;

namespace Second.Data_Access_Layer.Repository.Implementation
{
    public class ProductRepo : IProductRepo
    {
        private SecondzzDbContext dbContext;

        public ProductRepo(SecondzzDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Product> CreateAsync(Product products)
        {
            await dbContext.Products.AddAsync(products);
            await dbContext.SaveChangesAsync();
            return products;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var existingProducts = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existingProducts == null)
            {
                return null;
            }
            dbContext.Products.Remove(existingProducts);
            await dbContext.SaveChangesAsync();
            return existingProducts;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await dbContext.Products.Include("Category").Include("User").ToListAsync();

        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products.Include("Category").FirstOrDefaultAsync(x => x.ProductId == id);
        }



        public async Task<Product> UpdateAsync(int id, Product product)
        {
            var existingProduct = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existingProduct == null)
            {
                return null;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.ProductImageUrl = product.ProductImageUrl;
            existingProduct.ProductPrice = product.ProductPrice;
            existingProduct.ProductDetails = product.ProductDetails;
            existingProduct.CategoryId = product.CategoryId;
            

            await dbContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product> UpdateStatus(int id, Product product)
        {
            var existingJob = await dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
            if (existingJob == null)
            {
                return null;
            }
            existingJob.Status = product.Status;



            await dbContext.SaveChangesAsync();
            return existingJob;
        }
    }
}