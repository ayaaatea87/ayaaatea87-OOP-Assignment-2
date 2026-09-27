using System.Collections.Generic;

namespace Inheritance;

public class Member : Person
{
    private List<Loan> _loans = new List<Loan>();

    private int _maxLoans;
    private decimal _discountPercentage;

    public IReadOnlyList<Loan> Loans
    {
        get { return _loans.AsReadOnly(); }
    }

    protected Member(
        string personId,
        string fullName,
        string phone,
        int maxLoans,
        decimal discountPercentage)
        : base(personId, fullName, phone)
    {
        _maxLoans = maxLoans;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountPercentage
    {
        get { return _discountPercentage; }
    }

    public Loan Borrow(
        LibraryItem item,
        string loanId,
        DateTime borrowDate)
    {
        int activeLoans = 0;

        foreach (Loan loan in _loans)
        {
            if (loan.Status == LoanStatus.Borrowed)
                activeLoans++;
        }

        if (activeLoans >= _maxLoans)
            throw new Exception("Member has reached the maximum loan limit.");

        if (item.IsWithdrawn)
            throw new Exception("Withdrawn item cannot be borrowed.");

        if (item.IsOnLoan)
            throw new Exception("Item is already on loan.");

        Loan newLoan = new Loan(
            loanId,
            borrowDate,
            this,
            item);

        _loans.Add(newLoan);
        item.MarkAsBorrowed();

        return newLoan;
    }
}


public class StudentMember : Member
{
    public StudentMember(
        string personId,
        string fullName,
        string phone)
        : base(personId, fullName, phone, 3, 0)
    {
    }
}


public class PremiumMember : Member
{
    public int ReadingPoints
    {
        get
        {
            int returnedLoans = 0;

            foreach (Loan loan in Loans)
            {
                if (loan.Status == LoanStatus.Returned)
                    returnedLoans++;
            }

            return returnedLoans * 5;
        }
    }

    public PremiumMember(
        string personId,
        string fullName,
        string phone,
        decimal discountPercentage)
        : base(personId, fullName, phone, 10, discountPercentage)
    {
        if (discountPercentage < 0)
            throw new Exception("Discount cannot be negative.");
    }
}
