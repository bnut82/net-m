using MacrixPoc.User.Contracts;
using MacrixPoc.User.Contracts.Response;
using MediatR;

namespace MacrixPoc.User.Application.Query.Users;

public record UsersQueryHandler(IUserRepository Repository)  : IRequestHandler<UsersQuery, List<Model.User>>
{
    public async Task<List<Model.User>> Handle(UsersQuery request, CancellationToken cancellationToken)
    {
        return await Repository.GetUsers();
    }
}