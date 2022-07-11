using Iot.Class.Domain.Dtos;
using Iot.Class.Domain.ReadModels;
using MediatR;

namespace Iot.Class.Infatructure.Queries;

public record GetClassAllQuery : IRequest<IQueryable<ClassDto>>
{
    public GetClassAllQuery()
    {
        
    }
}