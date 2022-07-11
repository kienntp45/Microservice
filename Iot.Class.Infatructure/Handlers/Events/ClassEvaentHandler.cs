using System.Text.Json;

using AutoMapper;

using Iot.Class.Data.Reponsitoris.Interface;
using Iot.Class.Domain.Events;
using Iot.Class.Domain.ReadModels;
using Iot.Class.Infatructure.Commands.Classes;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace Iot.Class.Infatructure.Handlers.Events;

public class ClassEvaentHandler : INotificationHandler<ClassDeleteEvent>,
                                  INotificationHandler<ClassInitializedEvent>,
                                  INotificationHandler<ClassNameChangedEvent>,
                                  INotificationHandler<ClassPhoneNumberChangedEvent>,
                                  INotificationHandler<ClassTeacherChangedEvent>,
                                  INotificationHandler<ClassRoomChangedEvent>
{
    private readonly IClassRepository _repository;
    private readonly IMapper _mapper;

    public ClassEvaentHandler(IClassRepository classRepository, IMapper mapper)
    {
        _repository = classRepository ?? throw new ArgumentNullException(nameof(classRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }
    public async Task Handle(ClassInitializedEvent notification, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<ClassReadModel>(notification);

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

    }
    public async Task Handle(ClassDeleteEvent notification, CancellationToken cancellationToken)
    {
        var classChange = await _repository.AsQueryable()
            .FirstOrDefaultAsync(entity => Guid.Equals(entity.Id, notification.Id));
        if (classChange.IsDeleted)
            throw new ArgumentNullException("classId");


        classChange.IsDeleted = true;

        await _repository.RemoveAsync(classChange);
        await _repository.SaveChangesAsync();
    }
    public async Task Handle(ClassNameChangedEvent notification, CancellationToken cancellationToken)
    {
        var ClassChangeName = await _repository.AsQueryable().FirstOrDefaultAsync(c => Guid.Equals(c.Id, notification.Id));
        ClassChangeName.ClassName = notification.ClassName;
        await _repository.UpdateAsync(ClassChangeName);
        await _repository.SaveChangesAsync();
    }
    public async Task Handle(ClassPhoneNumberChangedEvent notification, CancellationToken cancellationToken)
    {
        var ClassChange = await _repository.AsQueryable().FirstOrDefaultAsync(c => Guid.Equals(c.Id, notification.Id));
        ClassChange.PhoneNumber = notification.PhoneNumber;
        await _repository.UpdateAsync(ClassChange);
        await _repository.SaveChangesAsync();
    }
    public async Task Handle(ClassRoomChangedEvent notification, CancellationToken cancellationToken)
    {
        var ClassChange = await _repository.AsQueryable().FirstOrDefaultAsync(c => Guid.Equals(c.Id, notification.Id));
        ClassChange.Room = notification.Room;
        await _repository.UpdateAsync(ClassChange);
        await _repository.SaveChangesAsync();
    }
    public async Task Handle(ClassTeacherChangedEvent notification, CancellationToken cancellationToken)
    {
        var ClassChange = await _repository.AsQueryable().FirstOrDefaultAsync(c => Guid.Equals(c.Id, notification.Id));
        ClassChange.Teacher = notification.Teacher;
        await _repository.UpdateAsync(ClassChange);
        await _repository.SaveChangesAsync();
    }
}