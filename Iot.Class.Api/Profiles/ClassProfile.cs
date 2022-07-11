using Iot.Class.Api.ViewModels;
using Iot.Class.Domain.Dtos;
using Iot.Class.Domain.ReadModels;
using Iot.Class.Infatructure.Commands.Classes;

namespace Iot.Class.Api.Profile;

public class ClassProfile:AutoMapper.Profile
{
    public ClassProfile()
    {
        CreateMap<CreateClassViewModel, CreateClassCommand>().ReverseMap();
        CreateMap<UpdateNameClassViewModel, UpdateClassCommand>().ReverseMap();
      
    }
    
}