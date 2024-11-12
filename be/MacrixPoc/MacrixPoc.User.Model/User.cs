using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacrixPoc.User.Model;

[Table("User")]
public class User
{
    [Key, Required] [Column("Id")] public Guid Id { get; set; }
    [Required]
    public required string FirstName { get; set; }
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
    public required string Phone { get; set; }
    public DateTime? BirthDate { get; set; }
}