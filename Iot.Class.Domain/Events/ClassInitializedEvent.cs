using System;
using Iot.Class.Domain.Event;

namespace Iot.Class.Domain.Events;

public class ClassInitializedEvent : ClassEventBase
{
    public ClassInitializedEvent(Guid id, string className, string teacher, string phoneNumber, int room) : base(id)
    {
        ClassName = className;
        Teacher = teacher;
        PhoneNumber = phoneNumber;
        Room = room;
    }
    public string ClassName { get; private set; }
    public string Teacher { get; private set; }
    public string PhoneNumber { get; private set; }
    public int Room { get; private set; }
}