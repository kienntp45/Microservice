using Iot.Class.Domain.Dtos;
using Iot.Class.Domain.ReadModels;

using MediatR;

namespace Iot.Class.Infatructure.Queries;

public class GetClassByIdQuery : IRequest<ClassDto>
{
    public GetClassByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}