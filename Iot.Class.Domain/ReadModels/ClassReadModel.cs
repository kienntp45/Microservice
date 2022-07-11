using System;
using Iot.Core.Domain.Entities;
using Iot.Core.Domain.Entities.Interfaces;

namespace Iot.Class.Domain.ReadModels;

public class ClassReadModel : Entity<Guid>
{
    public string ClassName { get; set; }
    public string Teacher { get; set; }
    public string PhoneNumber { get; set; }
    public int Room { get; set; }
    public bool IsDeleted { get; set; }
}