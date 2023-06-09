﻿using Secondzz.Data_Access_Layer.Models;

namespace Secondzz.Data_Access_Layer.Repository.Interface
{
    public interface IUserRepo
    {
        Task<User> CreateAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> UpdateAsync(int id, User user);
        Task<User> DeleteAsync(int id);
    }
}
