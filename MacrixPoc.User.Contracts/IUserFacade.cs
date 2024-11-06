using MacrixPoc.User.Contracts.Request;
using MacrixPoc.User.Contracts.Response;

namespace MacrixPoc.User.Contracts;

public interface IUserFacade
{
    public Task CreateUser(UserRequest request);
    public Task UpdateUser(UserRequest request , Guid id);
    public Task DeleteUser(Guid id);
    
    public Task<UserResponse> GetById(Guid id);
    public Task<List<UserResponse>> GetAll();
}