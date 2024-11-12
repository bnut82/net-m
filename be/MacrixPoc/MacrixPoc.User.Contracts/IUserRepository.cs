namespace MacrixPoc.User.Contracts;

public interface IUserRepository
{
    public Task CreateAsync(Model.User? model);
    public Task UpdateAsync(Model.User model);
    
    public Task<Model.User?> GetAsync(Guid id);
    public Task<List<Model.User>> GetUsersAsync();
    
    public Task DeleteAsync(Model.User model);
}