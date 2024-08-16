using BuyosferSozluk.Common;
using BuyosferSozluk.Common.Events.EntryComment;
using BuyosferSozluk.Common.Infrastructure;
using MediatR;

namespace BuyosferSozluk.Api.Application.Features.Commands.EntryComment.CreateFav;

public class CreateEntryCommentFavCommandHandler : IRequestHandler<CreateEntryCommentFavCommand, bool>
{
    public async Task<bool> Handle(CreateEntryCommentFavCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.CreateEntryCommentFavQueueName,
            obj: new CreateEntryCommentFavEvent()
            {
                EntryCommentId = request.EntryCommentId,
            });
    

        return await Task.FromResult(true);
    }
}
