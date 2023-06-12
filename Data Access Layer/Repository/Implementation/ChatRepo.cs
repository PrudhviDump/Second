using Microsoft.EntityFrameworkCore;
using Second.Data_Access_Layer.Models;
using Second.Data_Access_Layer.Repository.Interface;
using Secondzz.Data_Access_Layer.Context;
using Secondzz.Data_Access_Layer.Models;

namespace Second.Data_Access_Layer.Repository.Implementation
{
    public class ChatRepo : IChatRepo
    {
        private SecondzzDbContext dbContext;

        public ChatRepo(SecondzzDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Chat> CreateAsync(Chat chat)
        {
            await dbContext.Chats.AddAsync(chat);
            await dbContext.SaveChangesAsync();
            return chat;
        }

        public async Task<Chat> DeleteAsync(int id)
        {
            var existingChats = await dbContext.Chats.FirstOrDefaultAsync(x => x.MessageId == id);
            if (existingChats == null)
            {
                return null;
            }
            dbContext.Chats.Remove(existingChats);
            await dbContext.SaveChangesAsync();
            return existingChats;
        }

        public async Task<List<Chat>> GetAllAsync()
        {
            return await dbContext.Chats.Include(o => o.Sender).ThenInclude(o => o.Role).Include(o => o.Product).ThenInclude(o => o.Category).Include(o => o.Reciever).ThenInclude(o => o.Role).ToListAsync();

        }

        public async Task<Chat> GetByIdAsync(int id)
        {
            return await dbContext.Chats.Include(o => o.Sender).ThenInclude(o => o.Role).Include(o => o.Product).ThenInclude(o => o.Category).Include(o => o.Reciever).ThenInclude(o => o.Role).FirstOrDefaultAsync(x => x.MessageId == id);
        }

        public async Task<Chat>GetByProductIdAsync(int ProductId)
        {
            return await dbContext.Chats.Include(o => o.Sender).ThenInclude(o => o.Role).Include(o => o.Product).FirstOrDefaultAsync(x => x.ProductId == ProductId);
        }
    }
}