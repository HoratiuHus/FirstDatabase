using DataAccess.Models;

namespace DataAccess.Data.Interfaces
{
    public interface ITopicData
    {
        Task DeleteTopicAsync(int id);
        Task<Topic?> GetTopicByIDAsync(int id);
        Task<IEnumerable<Topic>> GetTopicsAsync();
        Task InsertTopicAsync(Topic topic);
        Task UpdateTopicAsync(Topic topic);
    }
}