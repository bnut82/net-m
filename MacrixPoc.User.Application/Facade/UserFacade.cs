using MacrixPoc.User.Application.Builder;
using MacrixPoc.User.Application.Command.UserCreate;
using MacrixPoc.User.Application.Command.UserDelete;
using MacrixPoc.User.Application.Command.UserUpdate;
using MacrixPoc.User.Application.Query.UserById;
using MacrixPoc.User.Application.Query.Users;
using MacrixPoc.User.Contracts;
using MacrixPoc.User.Contracts.Request;
using MacrixPoc.User.Contracts.Response;
using MediatR;

namespace MacrixPoc.User.Application.Facade;

public class UserFacade(IMediator mediator , IAgeBuilder builder) : IUserFacade
{
    public async Task CreateUser(UserRequest request)
    {
        var command = new UserCreateCommand()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            StreetName = request.StreetName,
            ApartmentNumber = request.ApartmentNumber,
            BirthDate = request.BirthDate,
            HouseNumber = request.HouseNumber,
            PostalCode = request.PostalCode,
            City = request.City,
            Phone = request.Phone
        };

        await mediator.Send(command);
    }

    public async Task UpdateUser(UserRequest request, Guid userId)
    {
        var command = new UserUpdateCommand
        {
            Id = userId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            StreetName = request.StreetName,
            ApartmentNumber = request.ApartmentNumber,
            PostalCode = request.PostalCode,
            City = request.City,
            Phone = request.Phone
        };

        await mediator.Send(command);
    }

    public async Task DeleteUser(Guid id)
    {
        await mediator.Send(new UserDeleteCommand() { Id = id });
    }

    public async Task<UserResponse> GetById(Guid id)
    {
        var result = await mediator.Send(new UserByIdQuery() { Id = id });
        return new UserResponse
        {
            FirstName = result.FirstName,
            LastName = result.LastName,
            StreetName = result.StreetName,
            HouseNumber = result.HouseNumber,
            ApartmentNumber = result.ApartmentNumber,
            PostalCode = result.PostalCode,
            City = result.City,
            Phone = result.Phone,
            BirthDate = result.BirthDate,
            Age = builder.Calculate(result.BirthDate)
        };
    }

    public async Task<List<UserResponse>> GetAll()
    {
        var models = await mediator.Send(new UsersQuery());

        return models.Select(item => new UserResponse
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                StreetName = item.StreetName,
                HouseNumber = item.HouseNumber,
                ApartmentNumber = item.ApartmentNumber,
                PostalCode = item.PostalCode,
                City = item.City,
                Phone = item.Phone,
                BirthDate = item.BirthDate,
                Age = builder.Calculate(item.BirthDate)
            })
            .ToList();
    }
}