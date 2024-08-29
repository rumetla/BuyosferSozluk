namespace BuyosferSozluk.WebApp.Infrastructure.Services.Interfaces
{
    public interface IVoteService
    {
        Task CreateEntryCommentDownvote(Guid entryCommentId);
        Task CreateEntryCommentUpvote(Guid entryCommentId);
        Task CreateEntryDownvote(Guid entryId);
        Task CreateEntryUpvote(Guid entryId);
        Task DeleteEntryCommentVote(Guid entryCommentId);
        Task DeleteEntryVote(Guid entryId);
    }
}