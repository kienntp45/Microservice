using System;
using Iot.Class.Domain.Event;

namespace Iot.Class.Domain.Events;

public class ClassTeacherChangedEvent:ClassEventBase
{
    public  ClassTeacherChangedEvent(Guid id, string teacher) : base(id)
    {
        Teacher = teacher;
    }
    public string Teacher { get; set; }
}