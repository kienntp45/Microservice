using AutoMapper;
using AutoMapper.QueryableExtensions;
using Iot.Class.Data.Reponsitoris.Interface;
using Iot.Class.Domain.Dtos;
using Iot.Class.Domain.ReadModels;
using Iot.Class.Infatructure.Queries;
using Iot.Core.Extensions;
using MediatR;

namespace Iot.Class.Infatructure.Handle.Query;

public class ClassHandleQuery:IRequestHandler<GetClassByIdQuery,ClassDto>, IRequestHandler<GetClassAllQuery,IQueryable<ClassDto>>
{
    private readonly IMapper _mapper;
    private readonly IClassRepository _reponsitoris;
    public ClassHandleQuery(IMapper mapper, IClassRepository reponsitoris)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _reponsitoris = reponsitoris ?? throw new ArgumentNullException(nameof(reponsitoris));
    }
    public Task<ClassDto> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _reponsitoris.AsQueryable().FirstOrDefault(c => (Guid.Equals(c.Id, request.Id)));
        var resultShow = _mapper.Map<ClassDto>(result);
        return Task.FromResult(resultShow);
    }

    public Task<IQueryable<ClassDto>> Handle(GetClassAllQuery request, CancellationToken cancellationToken)
    { //Sự kiện này bắt 
        var result = _reponsitoris.AsQueryable().ProjectTo<ClassDto>(_mapper.ConfigurationProvider);
        
        return Task.FromResult(result);
    }
}