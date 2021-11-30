using DataAccess.DBAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;
    const string GetAllUsers = "dbo.spUser_GetAll";
    const string GetUser_sp = "dbo.spUser_Get";
    const string InsertUser_sp = "dbo.spUser_Insert";
    const string UpdateUser_sp = "dbo.spUser_Update";
    const string DeleteUser_sp = "dbo.spUser_Delete";

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>(GetAllUsers, new { });

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(
            GetUser_sp,
            new { Id = id }
            );
        return results.FirstOrDefault();
    }

    public Task InsertUser(UserModel user) =>
        _db.SaveData(InsertUser_sp, parameters: new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) =>
        _db.SaveData(UpdateUser_sp, parameters: user);

    public Task DeleteUser(int id) =>
        _db.SaveData(DeleteUser_sp, parameters: new { Id = id });
}
