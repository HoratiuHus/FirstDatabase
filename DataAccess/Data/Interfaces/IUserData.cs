using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IUserData
    {
        Task DeleteUserAsync(int id);
        Task<User?> GetUserByIDAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task InsertUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}