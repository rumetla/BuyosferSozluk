using AutoMapper;
using BuyosferSozluk.Api.Domain.Models;
using BuyosferSozluk.Common.Models.Queries;
using BuyosferSozluk.Common.Models.RequestModels;

namespace BuyosferSozluk.Api.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, LoginUserViewModel>()
            .ReverseMap();

        CreateMap<CreateUserCommand, User>();

        CreateMap<UpdateUserCommand, User>();

        CreateMap<CreateEntryCommand, Entry>()
            .ReverseMap();

        CreateMap<CreateEntryCommentCommand, EntryComment>()
            .ReverseMap();
    }
}
