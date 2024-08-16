using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Api.Domain.Models;
using BuyosferSozluk.Api.Infrastructure.Persistence.Context;

namespace BuyosferSozluk.Api.Infrastructure.Persistence.Repositories;

public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
{
    public EntryCommentRepository(BuyosferSozlukContext dbContext) : base(dbContext)
    {

    }
}
