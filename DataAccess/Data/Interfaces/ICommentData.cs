using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    internal interface ICommentData
    {
        Task DeleteCommentAsync(int id);
        Task<User?> GetByPostIDAsync(int id);
        Task InsertCommentAsync(CommentModel comment);
        Task UpdateCommentAsync(CommentModel comment);
    }
}