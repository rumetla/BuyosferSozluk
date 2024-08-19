using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Common.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Api.Application.Features.Commands.User.ConfirmEmail;

public class ConfirmEmailCommand: IRequest<bool>
{
    public Guid ConfirmationId { get; set; }
    
}

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, bool>
{
    private readonly IUserRepository userRepository;
    private readonly IEmailConfirmationRepository emailConfirmationRepository;

    public ConfirmEmailCommandHandler(IUserRepository userRepository, IEmailConfirmationRepository emailConfirmationRepository)
    {
        this.userRepository = userRepository;
        this.emailConfirmationRepository = emailConfirmationRepository;
    }

    public async Task<bool> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var confirmation = await emailConfirmationRepository.GetByIdAsync(request.ConfirmationId);

        if (confirmation is null)
            throw new DatabaseValidationException("Confirmation not found!");
        
        var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == confirmation.NewEmailAddress);

        if (dbUser is null)
            throw new DatabaseValidationException("No user with this email found!");
        if (dbUser.EmailConfirmed)
            throw new DatabaseValidationException("Email address is already confirmed!");

        dbUser.EmailConfirmed = true;
        await userRepository.UpdateAsync(dbUser);

        return true;

    }
}

