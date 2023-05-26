﻿using Secondzz.Data_Access_Layer.Models;

namespace Second.Data_Access_Layer.Repository.Interface
{
    public class IProductRepo
    {
        Task<Product> CreateAsync(Product product);
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> UpdateAsync(int id, Product product);
        Task<Product> DeleteAsync(int id);
    }
}
