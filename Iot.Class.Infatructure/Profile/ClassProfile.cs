using Iot.Class.Domain.AggregateRoot;
using Iot.Class.Domain.Dtos;
using Iot.Class.Domain.Events;
using Iot.Class.Domain.ReadModels;
using Iot.Class.Infatructure.Queries;

namespace Iot.Class.Infatructure.Profile;

public class ClassProfile : AutoMapper.Profile
{
    public ClassProfile()
    {
        #region Dtos

        CreateMap<ClassAggregateRoot, ClassDto>().ReverseMap();
        CreateMap<GetClassByIdQuery, ClassDto>().ReverseMap();
        CreateMap<GetClassAllQuery, ClassDto>().ReverseMap();

        CreateMap<ClassReadModel, ClassDto>().ReverseMap();
        CreateMap<ClassInitializedEvent,ClassReadModel> ().ReverseMap();
        CreateMap<ClassNameChangedEvent,ClassReadModel> ().ReverseMap();
        CreateMap<ClassTeacherChangedEvent,ClassReadModel> ().ReverseMap();
        CreateMap<ClassPhoneNumberChangedEvent,ClassReadModel> ().ReverseMap();
        CreateMap<ClassRoomChangedEvent,ClassReadModel> ().ReverseMap();
       

        #endregion
    }
}