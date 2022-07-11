using System;
using Iot.Class.Domain.Event;

namespace Iot.Class.Domain.Events;

public class ClassRoomChangedEvent:ClassEventBase
{
    public ClassRoomChangedEvent(Guid id,int room) : base(id)
    {
        Room = room;
    }

    public int Room { get; set; }
}