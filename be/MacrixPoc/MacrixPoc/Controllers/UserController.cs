using MacrixPoc.User.Contracts;
using Microsoft.AspNetCore.Mvc;
using MacrixPoc.User.Contracts.Request;
using MacrixPoc.User.Contracts.Response;

namespace MacrixPoc.Controllers;

[Route("api/Users")]
[ApiController]
public class UserController(IUserFacade facade) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] UserRequest request)
    {
        await facade.CreateUser(request);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update([FromBody] UserRequest request , [FromRoute] Guid id)
    {
        await facade.UpdateUser(request , id);
        return NoContent();
    }

    [HttpGet()]
    public async Task<ActionResult<List<UserResponse>>> List()
    {
        return await facade.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserResponse>> Get(Guid id)
    {
        return await facade.GetById(id);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        await facade.DeleteUser(id);
        return Ok();
    }
}