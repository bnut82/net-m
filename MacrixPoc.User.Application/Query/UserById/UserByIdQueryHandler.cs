using MacrixPoc.User.Contracts;
using MacrixPoc.User.Contracts.Response;
using MediatR;

namespace MacrixPoc.User.Application.Query.UserById;

public record UserByIdQueryHandler(IUserRepository Repository) : IRequestHandler<UserByIdQuery , Model.User>
{
    public async Task<Model.User> Handle(UserByIdQuery request, CancellationToken cancellationToken)
    {
        return await Repository.Get(request.Id);
    }
}