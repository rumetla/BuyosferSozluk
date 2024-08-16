using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Api.Domain.Models;
using BuyosferSozluk.Api.Infrastructure.Persistence.Context;

namespace BuyosferSozluk.Api.Infrastructure.Persistence.Repositories;

public class EntryRepository : GenericRepository<Entry>, IEntryRepository
{
    public EntryRepository(BuyosferSozlukContext dbContext) : base(dbContext)
    {
    }
}
