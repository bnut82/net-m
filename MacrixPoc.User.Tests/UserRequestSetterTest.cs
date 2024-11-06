using MacrixPoc.User.Contracts.Request;

namespace MacrixPoc.User.Tests;

public class UserRequestSetterTest
{
    private UserRequest _dto;
    
    [SetUp]
    public void Setup()
    {
        _dto = new UserRequest
        {
            FirstName = "Test",
            LastName = "Test",
            StreetName = "Poznańska",
            HouseNumber = 12,
            PostalCode = "60100",
            City = "Poznań",
            Phone = "+48600100100"
        };
    }

    [Test]
    public void Test_SetFirstName()
    {
        const string value = "Test-new-code";
        _dto.FirstName = value;
        Assert.That(_dto.FirstName, Is.EqualTo(value));
    }

    [Test]
    public void Test_SetLastName()
    {
        const string value = "Test-new-code";
        _dto.LastName = value;
        Assert.That(_dto.LastName, Is.EqualTo(value));
    }

    [Test]
    public void Test_SetStreetName()
    {
        const string value = "Test-new-code";
        _dto.StreetName = value;
        Assert.That(_dto.StreetName , Is.EqualTo(value));
    }

    [Test]
    public void Test_SetHouseNumber()
    {
        const int value = 12;
        _dto.HouseNumber = value;
        Assert.That(_dto.HouseNumber, Is.EqualTo(value));
    }

    [Test]
    public void Test_SetPostalCode()
    {
        const string value = "60100-new-code";
        _dto.PostalCode = value;
        Assert.That(_dto.PostalCode, Is.EqualTo(value));
    }

    [Test]
    public void Test_SetCity()
    {
        const string value = "Poznań-new-code";
        _dto.City = value;
        Assert.That(_dto.City, Is.EqualTo(value));
    }

    [Test]
    public void Test_SetPhone()
    {
        const string value = "+48600100100-new-code";
        _dto.Phone = value;
        Assert.That(_dto.Phone, Is.EqualTo(value));
    }

    [Test]
    public void Test_SetDateOfBirth()
    {
        var value = new DateTime(2024,03,30 , 00, 00, 00);
        _dto.BirthDate = value;
        Assert.That(_dto.BirthDate, Is.EqualTo(value));
    }
}