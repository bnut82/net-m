using MacrixPoc.User.Contracts;
using MediatR;

namespace MacrixPoc.User.Application.Command.UserUpdate;

public class UserUpdateCommandHandler(IUserRepository repository) : IRequestHandler<UserUpdateCommand>
{
    public async Task Handle(UserUpdateCommand request, CancellationToken cancellationToken)
    {
        var model = await repository.GetAsync(request.Id);
        if (model != null)
        {
            model.City = request.City;
            model.FirstName = request.FirstName;
            model.ApartmentNumber = request.ApartmentNumber;
            model.LastName = request.LastName;
            model.HouseNumber = request.HouseNumber;
            model.Phone = request.Phone;
            model.BirthDate = request.BirthDate;
            model.PostalCode = request.PostalCode;
            model.StreetName = request.StreetName;
            
            await repository.UpdateAsync(model);
        }
        
        
        
    }
}