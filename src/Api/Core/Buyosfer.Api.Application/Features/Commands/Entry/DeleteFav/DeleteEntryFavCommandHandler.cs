﻿using BuyosferSozluk.Common;
using BuyosferSozluk.Common.Events.Entry;
using BuyosferSozluk.Common.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Api.Application.Features.Commands.Entry.DeleteFav;

public class DeleteEntryFavCommandHandler : IRequestHandler<DeleteEntryFavCommand, bool>
{
    public async Task<bool> Handle(DeleteEntryFavCommand request, CancellationToken cancellationToken) 
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.DeleteEntryFavQueueName,
            obj: new DeleteEntryFavEvent()
            {
                EntryId = request.EntryId,
                CreatedBy = request.UserId
            });
        return await Task.FromResult(true);
    }
}
