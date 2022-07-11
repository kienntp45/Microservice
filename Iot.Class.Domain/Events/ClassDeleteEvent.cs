using System;
using Iot.Class.Domain.Event;
using Iot.Core.Domain.Events;

namespace Iot.Class.Domain.Events;

public class ClassDeleteEvent:ClassEventBase
{
    public ClassDeleteEvent(Guid id):base(id)
    {
        IsDeleted = true;
        DeletedTime=DateTimeOffset.UtcNow;
    }
    public bool IsDeleted { get; set; }
    public DateTimeOffset DeletedTime { get; set; }
}