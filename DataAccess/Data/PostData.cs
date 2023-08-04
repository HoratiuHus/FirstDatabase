using DataAccess.DatabaseAccess;
using DataAccess.Models;
using DataAccess.Data.Interfaces;

namespace DataAccess.Data
{
    public class PostData : IPostData
    {
        private readonly ISqlDataAccess _db;

        public PostData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _db.LoadDataAsync<Post, dynamic>(storedProcedure: "dbo.spPost_GetAll", new { });
        }

        public async Task<Post?> GetPostByIDAsync(int id)
        {
            var results = await _db.LoadDataAsync<Post, dynamic>(
                storedProcedure: "dbo.spPost_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertPostAsync(Post post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Insert", new { post.Title, post.Body, post.User_ID, post.Topic_ID, post.UpVotes, post.DownVotes, CreatedAt = post.Created_At });
        }

        public Task UpdatePostAsync(Post post)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Update", post);
        }

        public Task DeletePostAsync(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spPost_Delete", new { Id = id });
        }
    }
}
