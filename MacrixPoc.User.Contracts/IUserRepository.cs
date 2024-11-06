namespace MacrixPoc.User.Contracts;

public interface IUserRepository
{
    public Task Create(Model.User? model);
    public Task Update(Model.User model);
    
    public Task<Model.User?> Get(Guid id);
    public Task<List<Model.User>> GetUsers();
    
    public Task DeleteAsync(Model.User model);
}