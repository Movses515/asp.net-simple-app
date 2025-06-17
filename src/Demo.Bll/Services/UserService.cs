using Demo.Bll.Interfaces;
using Demo.Bll.Mapper;
using Demo.Core.Context;
using Demo.Core.Records;
using Microsoft.EntityFrameworkCore;

namespace Demo.Bll.Services;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateUser user)
    {
        var entity = user.ToEntity();
        _context.Users.Add(entity);

        await _context.SaveChangesAsync();
    }

    public async Task<UserRecord[]> GetUsers()
    {
        var entities = await _context.Users
            .AsNoTracking()
            .ToArrayAsync();

        return entities.Select(entity => entity.ToRecord()).ToArray();
    }
}
