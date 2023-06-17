namespace RentalApp.Shared.Models;

[Flags]
public enum PersonRole
{
    Client = 0,
    Attendant = 1,
    Mechanic = 2,
    Owner = 4
}

public class Person
{
    public Person(int id, PersonRole role, string firstName, string lastName, string pesel, string phoneNumber,
        string employeeId, DateTimeOffset employmentDate, DateTimeOffset? dismissalDate)
    {
        Id = id;
        Role = role;
        FirstName = firstName;
        LastName = lastName;
        Pesel = pesel;
        PhoneNumber = phoneNumber;
        EmployeeId = employeeId;
        EmploymentDate = employmentDate;
        DismissalDate = dismissalDate;
    }

    public int Id { get; set; }
    public PersonRole Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; }

    // Client only properties
    public string PhoneNumber { get; set; }

    public IEnumerable<Rental> Rentals { get; set; } = new List<Rental>();

    // End client only properties

    // Employee only properties
    public string EmployeeId { get; set; }
    public DateTimeOffset EmploymentDate { get; set; }
    public DateTimeOffset? DismissalDate { get; set; }

    public Person? Supervisor { get; set; }
    public IEnumerable<Person> Subordinates { get; } = new List<Person>();

    // End employee only properties


    // Employee only methods
    private decimal CalculateSalary()
    {
        // TODO: Implement
        return 0;
    }

    // End employee only methods

    public void MakeClient(string phoneNumber)
    {
        Role |= PersonRole.Client;
    }

    public void MakeAttendant()
    {
        Role &= PersonRole.Client; // Preserve client status, clear employee status
        Role |= PersonRole.Attendant;
    }

    public void MakeMechanic()
    {
        Role &= PersonRole.Client; // Preserve client status, clear employee status
        Role |= PersonRole.Mechanic;
    }

    public void MakeOwner()
    {
        Role &= PersonRole.Client; // Preserve client status, clear employee status
        Role |= PersonRole.Owner;
    }
}