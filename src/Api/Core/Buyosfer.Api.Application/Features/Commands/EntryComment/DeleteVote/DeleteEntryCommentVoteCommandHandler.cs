using BuyosferSozluk.Common;
using BuyosferSozluk.Common.Events.EntryComment;
using BuyosferSozluk.Common.Infrastructure;
using MediatR;

namespace BuyosferSozluk.Api.Application.Features.Commands.EntryComment.DeleteVote;

public class DeleteEntryCommentVoteCommandHandler : IRequestHandler<DeleteEntryCommentVoteCommand, bool>
{
    public async Task<bool> Handle(DeleteEntryCommentVoteCommand request, CancellationToken cancellationToken)
    {
        QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.FavExchangeName,
            exchangeType: SozlukConstants.DefaultExchangeType,
            queueName: SozlukConstants.DeleteEntryCommentVoteQueueName,
            obj: new DeleteEntryCommentVoteEvent()
            {
                EntryCommentId = request.EntryCommentId,
                CreatedBy = request.UserId
            });
        return await Task.FromResult(true);
    }
}