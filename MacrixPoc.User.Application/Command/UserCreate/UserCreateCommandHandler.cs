using MacrixPoc.User.Contracts;
using MediatR;

namespace MacrixPoc.User.Application.Command.UserCreate
{
    public record UserCreateCommandHandler(IUserRepository Repository) : IRequestHandler<UserCreateCommand>
    {
        public async Task Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User.Model.User()
            {
                City = request.City,
                ApartmentNumber = request.ApartmentNumber,
                BirthDate = request.BirthDate,
                FirstName = request.FirstName,
                HouseNumber = request.HouseNumber,
                PostalCode = request.PostalCode,
                StreetName = request.StreetName,
                LastName = request.LastName,
                Phone = request.Phone,
            };

            await Repository.Create(user);
        }
    }
}