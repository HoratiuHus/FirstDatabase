using DataAccess.DatabaseAccess;
using DataAccess.Models;
using DataAccess.Data.Interfaces;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
       return await _db.LoadDataAsync<User, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });
    }

    public async Task<User?> GetUserByIDAsync(int id)
    {
        var results = await _db.LoadDataAsync<User, dynamic>(
            storedProcedure: "dbo.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault(); // This will return the first record in IEnumarable or the default value(null)
                                         //Here we are loading the data, we are asking of an IEnumerable of UserModel
                                         //And we are creating a new object(id) which is being passed by the constructor
    }

    public Task InsertUserAsync(User user)
    {
        return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Insert", new { user.Email, user.Username, user.Password, user.CreatedAt, user.Role });
    }

    public Task UpdateUserAsync(User user)
    {
        return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Update", user);
    }

    public Task DeleteUserAsync(int id)
    {
        return _db.SaveDataAsync(storedProcedure: "dbo.spUser_Delete", new { Id = id });
    }

}
