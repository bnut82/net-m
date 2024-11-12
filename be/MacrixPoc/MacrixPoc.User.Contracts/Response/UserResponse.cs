using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MacrixPoc.User.Contracts.Response;

public class UserResponse()
{
    public required Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string StreetName { get; set; }
    public int? HouseNumber { get; set; }
    public required string? ApartmentNumber { get; set; }
    public required string PostalCode { get; set; }
    public required string City { get; set; }
    public required string Phone { get; set; }
    public DateTime? BirthDate { get; set; } 
    public int Age { get; set; }
}