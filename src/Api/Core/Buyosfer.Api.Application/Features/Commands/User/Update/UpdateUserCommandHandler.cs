using AutoMapper;
using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Common;
using BuyosferSozluk.Common.Events.User;
using BuyosferSozluk.Common.Infrastructure;
using BuyosferSozluk.Common.Infrastructure.Exceptions;
using BuyosferSozluk.Common.Models.RequestModels;
using MediatR;

namespace BuyosferSozluk.Api.Application.Features.Commands.User.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var dbUser = await userRepository.GetByIdAsync(request.Id);

        if (dbUser == null)
            throw new DatabaseValidationException("User not found!");

        var dbEmailAddress = dbUser.EmailAddress;
        var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EmailAddress) != 0;

        var @event = new UserEmailChangedEvent();

        if (emailChanged)
        {
            @event.OldEmailAddress = dbEmailAddress;  // Set the OldEmailAddress before mapping
        }

        mapper.Map(request, dbUser);

        var rows = await userRepository.UpdateAsync(dbUser);

        if (emailChanged && rows > 0)
        {
            @event.NewEmailAddress = dbUser.EmailAddress;

            QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                               exchangeType: SozlukConstants.DefaultExchangeType,
                                               queueName: SozlukConstants.UserEmailChangedQueueName,
                                               obj: @event);

            dbUser.EmailConfirmed = false;
            await userRepository.UpdateAsync(dbUser);
        }
        return dbUser.Id;
    }
}
