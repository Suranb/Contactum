using System;
using System.ComponentModel.DataAnnotations;

namespace Contactum.Domain.Models;

public class Person
{
    [Key] public int PersonId { get; set; }
    [Required] public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    public DateTime DateOfBirth { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
