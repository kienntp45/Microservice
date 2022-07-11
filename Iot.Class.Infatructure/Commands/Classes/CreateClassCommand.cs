using Iot.Class.Domain.Dtos;
using MediatR;

namespace Iot.Class.Infatructure.Commands.Classes;

public class CreateClassCommand:IRequest<ClassDto>
{
    public CreateClassCommand(Guid id)
    {
        Id = id;
     
    }
    public Guid Id { get; private set; }
    public string ClassName { get; set; }
    public string Teacher { get; set; }
    public string PhoneNumber { get; set; }
    public int Room { get; set; }
}