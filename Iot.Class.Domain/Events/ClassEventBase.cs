using System;
using Iot.Core.Domain.Events;

namespace Iot.Class.Domain.Event;

public class ClassEventBase : EventBase
{
    internal ClassEventBase(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}