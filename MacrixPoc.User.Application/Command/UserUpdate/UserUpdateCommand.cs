using MediatR;

namespace MacrixPoc.User.Application.Command.UserUpdate;

public record UserUpdateCommand : IRequest
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string StreetName { get; init; }
    public int HouseNumber { get; init; }
    public string? ApartmentNumber { get; init; }
    public required string PostalCode { get; init; }
    public required string City { get; init; }
    public required string Phone { get; init; }
    public DateTime? BirthDate { get; set; }
}