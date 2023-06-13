using Secondzz.Data_Access_Layer.Models;
using System.Diagnostics.Contracts;

namespace Second.Data_Access_Layer.Repository.Interface
{
    public interface IProductRepo
    {
        Task<Product> CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateAsync(int id, Product product);
        Task<Product> DeleteAsync(int id);
        Task<Product> UpdateStatus(int id, Product product);
    }
}
