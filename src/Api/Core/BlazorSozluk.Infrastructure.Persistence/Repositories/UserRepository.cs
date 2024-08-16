using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Api.Domain.Models;
using BuyosferSozluk.Api.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Api.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(BuyosferSozlukContext dbContext) : base(dbContext)
    {
    }
}
