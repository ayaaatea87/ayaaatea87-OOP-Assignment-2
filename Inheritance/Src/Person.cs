namespace Inheritance;

public class Person
{
    public string PersonId { get; }
    public string FullName { get; }
    public string Phone { get; }

    protected Person(string personId, string fullName, string phone)
    {
        if (string.IsNullOrEmpty(personId))
            throw new Exception("Person ID cannot be empty.");

        if (string.IsNullOrEmpty(fullName))
            throw new Exception("Full name cannot be empty.");

        if (string.IsNullOrEmpty(phone))
            throw new Exception("Phone cannot be empty.");

        PersonId = personId;
        FullName = fullName;
        Phone = phone;
    }
}
