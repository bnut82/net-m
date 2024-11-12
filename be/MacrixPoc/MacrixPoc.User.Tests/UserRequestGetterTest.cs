using MacrixPoc.User.Contracts.Request;

namespace MacrixPoc.User.Tests;

public class UserRequestGetterTest
{
    private UserRequest _dto;
    
    [SetUp]
    public void Setup()
    {
        _dto = new UserRequest()
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
    public void Test_ReturnsFirstName()
    {
        Assert.That(_dto.FirstName, Is.EqualTo("Test"));
    }

    [Test]
    public void Test_ReturnsLastName()
    {
        Assert.That(_dto.LastName, Is.EqualTo("Test"));
    }

    [Test]
    public void Test_ReturnsStreetName()
    {
        Assert.That(_dto.StreetName, Is.EqualTo("Poznańska"));
    }

    [Test]
    public void Test_ReturnsHouseNumber()
    {
        Assert.That(_dto.HouseNumber, Is.EqualTo(12));
    }

    [Test]
    public void Test_ReturnsPostalCode()
    {
        Assert.That(_dto.PostalCode, Is.EqualTo("60100"));
    }

    [Test]
    public void Test_ReturnsCity()
    {  
        Assert.That(_dto.City , Is.EqualTo("Poznań"));
    }

    [Test]
    public void Test_ReturnsPhone()
    {
        Assert.That(_dto.Phone, Is.EqualTo("+48600100100"));
    }
}