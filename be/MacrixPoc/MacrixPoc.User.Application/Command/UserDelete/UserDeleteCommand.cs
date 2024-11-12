using MediatR;

namespace MacrixPoc.User.Application.Command.UserDelete;

public record UserDeleteCommand : IRequest
{
    public Guid Id { get; init; }
}