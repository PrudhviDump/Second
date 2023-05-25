using Microsoft.EntityFrameworkCore;
using Secondzz.Data_Access_Layer.Models;
using Secondzz.Data_Access_Layer.Repository.Interface;
using Secondzz.Data_Access_Layer.Context;
namespace Secondzz.Data_Access_Layer.Repository.Implementation
{
    public class UserRepo : IUserRepo
    {
        private SecondzzDbContext dbContext;

        public UserRepo(SecondzzDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteAsync(int id)
        {
            var existingUsers = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existingUsers == null)
            {
                return null;
            }
            dbContext.Users.Remove(existingUsers);
            await dbContext.SaveChangesAsync();
            return existingUsers;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.Include("Role").ToListAsync();

        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await dbContext.Users.Include("Role").FirstOrDefaultAsync(x => x.UserId == id);
        }



        public async Task<User> UpdateAsync(int id, User user)
        {
            var existingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.UserId == id);
            if (existingUser == null)
            {
                return null;
            }
            existingUser.UserName = user.UserName;
            existingUser.EmailId = user.EmailId;
            existingUser.Password = user.Password;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.RoleId = user.RoleId;

            await dbContext.SaveChangesAsync();
            return existingUser;
        }
    }
}