using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface ICommentData
    {
        Task DeleteCommentAsync(int id);
        Task<User?> GetByPostIDAsync(int id);
        Task InsertCommentAsync(Comments comment);
        Task UpdateCommentAsync(Comments comment);
    }
}