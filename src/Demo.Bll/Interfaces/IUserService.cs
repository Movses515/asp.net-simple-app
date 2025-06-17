using Demo.Core.Records;

namespace Demo.Bll.Interfaces;

public interface IUserService
{
    Task<UserRecord[]> GetUsers();
    Task CreateAsync(CreateUser user);
}
