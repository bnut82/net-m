using System.ComponentModel.DataAnnotations;

namespace MacrixPoc.User.Contracts.Request;

public sealed class UserRequest
{
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string StreetName { get; set; }
    [Required]
    public required int HouseNumber { get; set; }
    public string? ApartmentNumber { get; set; }
    [Required]
    public required string PostalCode { get; set; }
    [Required]
    public required string City { get; set; }
    [Required]
    public required string Phone { get; set; }
    public DateTime? BirthDate { get; set; }   
}