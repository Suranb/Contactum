namespace Contactum.Domain.Models;

public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? OrganizationNumber { get; set; }
    public string? Description { get; set; }


    public int? OwnerId { get; set; }
    public int? ContactPersonId { get; set; }
    public Person? Owner { get; set; }
    public Person? ContactPerson { get; set; }


    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    private Company() { }

    public Company(
        string? name, 
        int? organizationNumber = null, 
        string? description = null,
        int? ownerId = null,
        int? contactPersonId = null)
    {
        Name = name;
        Description = description;
        OrganizationNumber = organizationNumber;
        OwnerId = ownerId;
        ContactPersonId = contactPersonId;
        CreatedAt = DateTime.UtcNow.AddHours(1);
        UpdatedAt = DateTime.UtcNow.AddHours(1);
    }
}