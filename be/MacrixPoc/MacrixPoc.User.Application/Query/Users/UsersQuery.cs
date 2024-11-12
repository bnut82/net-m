using MacrixPoc.User.Contracts.Response;
using MediatR;

namespace MacrixPoc.User.Application.Query.Users;

public record UsersQuery() : IRequest<List<Model.User>>
{
}