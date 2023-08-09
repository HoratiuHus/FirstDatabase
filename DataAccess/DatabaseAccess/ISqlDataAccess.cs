namespace DataAccess.DatabaseAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task<(IEnumerable<T>, IEnumerable<V>)> LoadDataAsync<T, V, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}