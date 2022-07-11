using System;
using Iot.Class.Domain.Events;
using Iot.Core.Domain.AggregateRoots;
using Iot.Core.Extensions;

namespace Iot.Class.Domain.AggregateRoot;

public class ClassAggregateRoot : FullAggregateRoot<Guid>
{
    public ClassAggregateRoot(Guid id)
    {
        if (id.IsNullOrDefault())
            throw new ArgumentNullException("Class Id");
        Id = id;

    }

    public string ClassName { get; private set; }
    public string Teacher { get; private set; }
    public string PhoneNumber { get; private set; }
    public int Room { get; private set; }

    public string StreamName => $"Class-{Id}"; // định nghĩa StreamName phục vụ cho EventStore

    public ClassAggregateRoot Initialize(string className, string teacher, string phoneNumber, int room)
    {
        if (className.IsNullOrDefault())
            return this;

        if (teacher.IsNullOrDefault())
            return this;

        var @event = new ClassInitializedEvent(Id, className, teacher, phoneNumber, room);
        AddDomainEvent(@event);
        Apply(@event);
        return this;

    }

    private void Apply(ClassInitializedEvent @event)
    {
        Id = @event.Id;
        ClassName = @event.ClassName;
        Teacher = @event.Teacher;
        PhoneNumber = @event.PhoneNumber;
        Room = @event.Room;
    }

    public ClassAggregateRoot ChangeName(string className)
    {
        if (className.IsNullOrDefault())
            return this;

        var @event = new ClassNameChangedEvent(Id, className);
        AddDomainEvent(@event);
        Apply(@event);
        return this;

    }

    private void Apply(ClassNameChangedEvent @event)
    {
        Id = @event.Id;
        ClassName = @event.ClassName;
    }

    public ClassAggregateRoot ChangeTeacher(string teacher)
    {
        if (teacher.IsNullOrDefault())
            return this;

        var @event = new ClassTeacherChangedEvent(Id, teacher);
        AddDomainEvent(@event);
        Apply(@event);
        return this;

    }

    private void Apply(ClassTeacherChangedEvent @event)
    {
        Id = @event.Id;
        Teacher = @event.Teacher;
    }

    public ClassAggregateRoot ChangePhoneNumber(string phoneNumber)
    {
        if (PhoneNumber.IsNullOrDefault())
            return this;

        var @event = new ClassPhoneNumberChangedEvent(Id, phoneNumber);
        AddDomainEvent(@event);
        Apply(@event);
        return this;

    }

    private void Apply(ClassPhoneNumberChangedEvent @event)
    {
        Id = @event.Id;
        PhoneNumber = @event.PhoneNumber;
    }

    public ClassAggregateRoot ChangeRoom(int room)
    {
        if (room.IsNullOrDefault())
            return this;

        var @event = new ClassRoomChangedEvent(Id, room);
        AddDomainEvent(@event);
        Apply(@event);
        return this;

    }

    private void Apply(ClassRoomChangedEvent @event)
    {
        Id = @event.Id;
        Room = @event.Room;
    }
    public ClassAggregateRoot Delete(Guid id)
    {
        if (id.IsNullOrDefault())
            return this;

        var @event = new ClassDeleteEvent(Id);
        AddDomainEvent(@event);
        Apply(@event);
        return this;

    }

    private void Apply(ClassDeleteEvent @event)
    {
        Id = @event.Id;
        IsDeleted = true;
    }
}