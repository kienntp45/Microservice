using AutoMapper;
using Iot.Class.Api.ViewModels;
using Iot.Class.Domain.Dtos;
using Iot.Class.Infatructure.Commands.Classes;
using Iot.Class.Infatructure.Queries;
using Iot.Core.AspNetCore.Exceptions;
using Iot.Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;

namespace Iot.Class.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClassController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("{key}")]
        [EnableQuery]

        public async Task<ClassDto> GetAsync([FromODataUri] Guid key)
        {
            if (key.IsNullOrDefault()) // kiểm tra Key Chuyền vào. nếu Null thì thông đưa ra thông báo.
                throw new BadRequestException("Id can not be null.");
            var query = new GetClassByIdQuery(key); // tạo mới 1 biến có kiểu dữ liệu là GetClassById và truyền vào Key là Id của dòng dữ liệu mình lấy ra.
            var result = await _mediator.Send(query); // gửi query  để cho Handler nhận và thực thi rồi trả ra giá trị có kiểu dữ liệu là ClassDto 
            return result;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<IQueryable<ClassDto>> GetAsync()
        {
            return await _mediator.Send(new GetClassAllQuery());
        }

        [HttpPost]
        public async Task<ClassDto> PostAsync([FromBody] CreateClassViewModel viewModel)
        {
            var command = new CreateClassCommand(Guid.NewGuid());
            command = _mapper.Map(viewModel, command);
            return await _mediator.Send(command);
        }

        [HttpPut("{key}")]
        public async Task<ClassDto> PutAsync(Guid key, [FromBody] UpdateNameClassViewModel viewModel)
        {
            var command = new UpdateClassCommand(key);
            command= _mapper.Map(viewModel, command);
            return await _mediator.Send(command);
        }

        [HttpDelete("{key}")]
        public async Task<ClassDto> DeleteAsync(Guid key)
        {
            var command = new RemoveClassCommand(key);
            return await _mediator.Send(command);
        }

    }
}
