using AutoMapper;
using BuyosferSozluk.Api.Application.Interfaces.Repositories;
using BuyosferSozluk.Common.Models.RequestModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyosferSozluk.Api.Application.Features.Commands.EntryComment.Create;

public class CreateEntryCommentCommandHandler: IRequestHandler<CreateEntryCommentCommand, Guid>
{
    private readonly IEntryCommentRepository entryCommentRepository;
    private readonly IMapper mapper;

    public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
    {
        this.entryCommentRepository = entryCommentRepository;
        this.mapper = mapper;
    }

    public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
    {
        var dbEntryComment = mapper.Map<Domain.Models.EntryComment>(request);
        
        await entryCommentRepository.AddAsync(dbEntryComment);

        return dbEntryComment.Id;    
    }
}
