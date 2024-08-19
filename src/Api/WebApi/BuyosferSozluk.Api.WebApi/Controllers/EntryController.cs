using BuyosferSozluk.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuyosferSozluk.Api.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]

public class EntryController : BaseController
{
    private readonly IMediator mediator;

    [HttpPost]
    [Route("CreateEntry")]
    public async Task<IActionResult> CreateEntry([FromBody] CreateEntryCommand command)
    {
        if (!command.CreatedById.HasValue)
            command.CreatedById = UserId;

        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpPost]
    [Route("CreateEntryComment")]

    public async Task<IActionResult> CreateEntryComment([FromBody] CreateEntryCommentCommand command)
    {
        if (!command.CreatedById.HasValue)
            command.CreatedById = UserId;
        
        var result = await mediator.Send(command);

        return Ok(result);
    }
}
