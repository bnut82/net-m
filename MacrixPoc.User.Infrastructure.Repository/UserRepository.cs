using System.Data.Entity;
using Macrix.Database;
using MacrixPoc.User.Contracts;
using Microsoft.EntityFrameworkCore;

namespace MacrixPoc.User.Infrastructure.Repository;

public class UserRepository(MacrixContext context) : IUserRepository
{
    public async Task Create(Model.User? model)
    {
        context.Users.Add(model);
        await context.SaveChangesAsync();
    }

    public async Task Update(Model.User model)
    {
        context.Users.Update(model);
        await context.SaveChangesAsync();
    }

    public async Task<Model.User?> Get(Guid id)
    {
        return await context.Users.FindAsync(id);
    }

    public async Task<List<Model.User>> GetUsers()
    {
        return await Task.FromResult(
            (
                from u in context.Users
                select u
            ).ToList());
    }

    public async Task DeleteAsync(Model.User model)
    {
        context.Users.Remove(model);
        await context.SaveChangesAsync();
    }
}