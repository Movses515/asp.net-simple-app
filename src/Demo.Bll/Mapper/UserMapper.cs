using Demo.Core.Entities;
using Demo.Core.Records;

namespace Demo.Bll.Mapper;

public static class UserMapper
{
    public static User ToEntity(this CreateUser createUser)
    {
        return new User
        {
            Name = createUser.Name,
            Email = createUser.Email,
            Surname = createUser.Surname,
            Password = BCrypt.Net.BCrypt.HashPassword(createUser.Password)
        };
    }

    public static UserRecord ToRecord(this User user)
    {
        return new UserRecord(user.Name, user.Surname, user.Email);
    }
}
