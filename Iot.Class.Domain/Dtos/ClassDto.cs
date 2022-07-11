using System;

namespace Iot.Class.Domain.Dtos;

public class ClassDto
{
    public Guid Id { get; set; }
    public string ClassName { get; set; }
    public string Teacher { get; set; }
    public string PhoneNumber { get; set; }
    public int Room { get; set; }
  
}