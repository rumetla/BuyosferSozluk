﻿using BuyosferSozluk.Common.Models.Queries;
using MediatR;

namespace BuyosferSozluk.Common.Models.RequestModels;

public class LoginUserCommand : IRequest<LoginUserViewModel>
{
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public LoginUserCommand(string emailAddress, string password)
    {
        EmailAddress = emailAddress;
        Password = password;
    }

    public LoginUserCommand() 
    {
        
    }
}
