using MacrixPoc.User.Contracts;
using MediatR;

namespace MacrixPoc.User.Application.Command.UserDelete;

public record UserDeleteCommandHandler(IUserRepository Repository) : IRequestHandler<UserDeleteCommand>
{
    public async Task Handle(UserDeleteCommand request, CancellationToken cancellationToken)
    {
        if (request.Id != Guid.Empty)
        {
            var model = await Repository.GetAsync(request.Id);
            if (model != null)
            {
                await Repository.DeleteAsync(model);
            }
        }
        
    }
}