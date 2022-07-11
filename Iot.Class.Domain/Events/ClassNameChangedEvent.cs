using System;
using Iot.Class.Domain.Event;

namespace Iot.Class.Domain.Events;

public class ClassNameChangedEvent:ClassEventBase
{
    public  ClassNameChangedEvent(Guid id, string className) : base(id)
    {
        ClassName = className;
    }

    public string ClassName { get; set; }
}