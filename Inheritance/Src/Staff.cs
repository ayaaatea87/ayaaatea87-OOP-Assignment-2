namespace Inheritance;

public class Staff : Person
{
    public DateTime HireDate { get; }

    public decimal MonthlySalary { get; private set; }

    private decimal _responsibilityAllowance;

    protected Staff(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary,
        decimal responsibilityAllowance)
        : base(personId, fullName, phone)
    {
        HireDate = hireDate;
        MonthlySalary = monthlySalary;
        _responsibilityAllowance = responsibilityAllowance;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new Exception("Raise percentage must be greater than zero.");

        MonthlySalary += MonthlySalary * percentage / 100;
    }

    public decimal MonthlyPay
    {
        get { return MonthlySalary + _responsibilityAllowance; }
    }
}


public class Librarian : Staff
{
    public Librarian(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary)
        : base(
            personId,
            fullName,
            phone,
            hireDate,
            monthlySalary,
            0)
    {
    }

    public void ProcessReturn(Loan loan, DateTime returnDate)
    {
        loan.Return(returnDate);
    }

    public void MarkAsLost(Loan loan)
    {
        loan.MarkAsLost();
    }
}


public class Shelver : Staff
{
    public string Section { get; private set; }

    public Shelver(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary,
        string section)
        : base(
            personId,
            fullName,
            phone,
            hireDate,
            monthlySalary,
            0)
    {
        if (string.IsNullOrEmpty(section))
            throw new Exception("Section cannot be empty.");

        Section = section;
    }

    public void Reassign(string section)
    {
        if (string.IsNullOrEmpty(section))
            throw new Exception("Section cannot be empty.");

        Section = section;
    }
}


public class HeadLibrarian : Staff
{
    public HeadLibrarian(
        string personId,
        string fullName,
        string phone,
        DateTime hireDate,
        decimal monthlySalary)
        : base(
            personId,
            fullName,
            phone,
            hireDate,
            monthlySalary,
            400)
    {
    }

    public void ChangeLateFee(
        LibraryItem item,
        decimal newFee)
    {
        item.ChangePricing(newFee);
    }

    public void Withdraw(LibraryItem item)
    {
        item.Withdraw();
    }

    public void Restore(LibraryItem item)
    {
        item.Restore();
    }
}
