using DataAccess.Data.Interfaces;
using DataAccess.DatabaseAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    internal class CommentData : ICommentData
    {
        private readonly ISqlDataAccess _db;

        public CommentData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<User?> GetByPostIDAsync(int id)
        {
            var results = await _db.LoadDataAsync<User, dynamic>(
                storedProcedure: "dbo.spComment_Get",
                new { Id = id });
            return results.FirstOrDefault();
        }

        public Task InsertCommentAsync(Comments comment)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Insert", new { comment.User_Id, comment.Comment, comment.Post_Id, comment.Topic_Id });
        }

        public Task UpdateCommentAsync(Comments comment)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Update", comment);
        }

        public Task DeleteCommentAsync(int id)
        {
            return _db.SaveDataAsync(storedProcedure: "dbo.spComment_Delete", new { Id = id });
        }
    }
}
