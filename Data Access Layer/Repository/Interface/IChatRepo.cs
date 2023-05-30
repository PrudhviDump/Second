using Second.Data_Access_Layer.Models;

namespace Second.Data_Access_Layer.Repository.Interface
{
    public interface IChatRepo
    {
        Task<Chat> CreateAsync(Chat chat);
        Task<List<Chat>> GetAllAsync();
        Task<Chat> GetByIdAsync(int id);
        Task<Chat> DeleteAsync(int id);
    }
}
