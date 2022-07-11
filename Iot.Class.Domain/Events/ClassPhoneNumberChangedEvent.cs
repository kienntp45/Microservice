using System;
using Iot.Class.Domain.Event;
using Iot.Core.Domain.Events;

namespace Iot.Class.Domain.Events;

public class ClassPhoneNumberChangedEvent : ClassEventBase
{
    public ClassPhoneNumberChangedEvent(Guid id, string phoneNumber) : base(id)
    {
        PhoneNumber = phoneNumber;
    }
    public string PhoneNumber { get; set; }
}