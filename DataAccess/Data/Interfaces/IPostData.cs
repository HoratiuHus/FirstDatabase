using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface IPostData
    {
        Task DeletePostAsync(int id);
        Task<Post?> GetPostByIDAsync(int id);
        Task<IEnumerable<Post>> GetPostsAsync();
        Task InsertPostAsync(Post post);
        Task UpdatePostAsync(Post post);
    }
}