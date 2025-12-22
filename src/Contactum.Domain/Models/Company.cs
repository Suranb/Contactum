using System;
using System.ComponentModel.DataAnnotations;

namespace Contactum.Domain.Models;

public class Company
{
    [Key] public int Id { get; set; }
    [MinLength(2)] public string Name { get; set; }
    public int? OrganizationNumber { get; set; } // Not Required for now
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
