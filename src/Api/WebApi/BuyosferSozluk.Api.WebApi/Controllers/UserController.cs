﻿using BuyosferSozluk.Api.Application.Features.Commands.User.ConfirmEmail;
using BuyosferSozluk.Api.Application.Features.Queries.GetUserDetail;
using BuyosferSozluk.Common.Events.User;
using BuyosferSozluk.Common.Infrastructure.Exceptions;
using BuyosferSozluk.Common.Models.RequestModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuyosferSozluk.Api.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]

public class UserController : BaseController
{
    private readonly IMediator mediator;

    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }


    [HttpGet("{id}")]
    
    public async Task<IActionResult> Get(Guid id)
    {
        var user = await mediator.Send(new GetUserDetailQuery(id));

        return Ok(user);
    }


    [HttpGet]
    [Route("UserName/{userName}")]

    public async Task<IActionResult> GetByUserName(string userName)
    {
        var user = await mediator.Send(new GetUserDetailQuery(Guid.Empty, userName));

        return Ok(user);
    }
    

    [HttpPost]
    [Route("Login")]
    [AllowAnonymous]

    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        try
        {
            var res = await mediator.Send(command);
            return Ok(res);
        }
        catch (DatabaseValidationException ex)
        {
            // Handle specific validation exception
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception ex)
        {
            // Handle unexpected exceptions
            return StatusCode((int)HttpStatusCode.InternalServerError, new { message = "An unexpected error occurred. Please try again later." });
        }
    }

    [HttpPost]
	[Authorize]

	public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var guid = await mediator.Send(command);

        return Ok(guid);
    }

    [HttpPost]
    [Route("Update")]
	[Authorize]

	public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
    {
        var guid = await mediator.Send(command);

        return Ok(guid);
    }
    
    [HttpPost]
    [Route("Confirm")]

	public async Task<IActionResult> ConfirmEmail(Guid id)
    {
        var guid = await mediator.Send(new ConfirmEmailCommand() { ConfirmationId = id});

        return Ok(guid);
    }

    [HttpPost]
    [Route("ChangePassword")]
	[Authorize]

	public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand command)
    {
        if(!command.UserId.HasValue)
            command.UserId = UserId;

        var guid = await mediator.Send(command);

        return Ok(guid);
    }
}
