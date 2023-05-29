using Second.Data_Access_Layer.Models;

namespace Second.Data_Access_Layer.Repository.Interface
{
    public interface IChatRepo
    {
        Task<Chat> CreateAsync(Chat chat);
        Task<List<Message>> GetAllAsync();
        Task<Message> GetByIdAsync(int id);
        Task<Message> DeleteAsync(int id);
    }
}
