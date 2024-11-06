using MacrixPoc.User.Contracts.Response;
using MediatR;


namespace MacrixPoc.User.Application.Query.UserById;

public record UserByIdQuery : IRequest<Model.User> 
{
    public Guid Id { get; init; }
}