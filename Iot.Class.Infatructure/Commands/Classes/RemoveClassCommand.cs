using Iot.Class.Domain.Dtos;
using MediatR;

namespace Iot.Class.Infatructure.Commands.Classes;

public class RemoveClassCommand:IRequest<ClassDto>, INotification
{
    public RemoveClassCommand(Guid id)
    {
        Id = id;
       
    }
    public Guid Id { get;  set; }
   
}