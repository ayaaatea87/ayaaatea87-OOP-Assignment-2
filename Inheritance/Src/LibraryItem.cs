namespace Inheritance;

public class LibraryItem
{
    public string CatalogNumber { get; }
    public string Title { get; }

    public decimal BaseLateFee { get; private set; }

    public bool IsWithdrawn { get; private set; }

    public bool IsOnLoan { get; private set; }

    private int _loanPeriodDays;
    private decimal _lateFeeMultiplier;

    protected LibraryItem(
        string catalogNumber,
        string title,
        decimal baseLateFee,
        int loanPeriodDays,
        decimal lateFeeMultiplier)
    {
        if (string.IsNullOrEmpty(catalogNumber))
            throw new Exception("Catalog number cannot be empty.");

        if (string.IsNullOrEmpty(title))
            throw new Exception("Title cannot be empty.");

        if (baseLateFee <= 0)
            throw new Exception("Late fee must be greater than zero.");

        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        _loanPeriodDays = loanPeriodDays;
        _lateFeeMultiplier = lateFeeMultiplier;
    }

    public int LoanPeriodDays
    {
        get { return _loanPeriodDays; }
    }

    public decimal DailyLateFee
    {
        get { return BaseLateFee * _lateFeeMultiplier; }
    }

    public void ChangePricing(decimal newFee)
    {
        if (newFee <= 0)
            throw new Exception("Late fee must be greater than zero.");

        BaseLateFee = newFee;
    }

    public void Withdraw()
    {
        IsWithdrawn = true;
    }

    public void Restore()
    {
        IsWithdrawn = false;
    }

    internal void MarkAsBorrowed()
    {
        IsOnLoan = true;
    }

    internal void MarkAsReturned()
    {
        IsOnLoan = false;
    }
}


public class Book : LibraryItem
{
    public Book(
        string catalogNumber,
        string title,
        decimal baseLateFee)
        : base(
            catalogNumber,
            title,
            baseLateFee,
            21,
            1)
    {
    }
}


public class DVD : LibraryItem
{
    public DVD(
        string catalogNumber,
        string title,
        decimal baseLateFee)
        : base(
            catalogNumber,
            title,
            baseLateFee,
            7,
            2)
    {
    }
}


public class Magazine : LibraryItem
{
    public Magazine(
        string catalogNumber,
        string title,
        decimal baseLateFee)
        : base(
            catalogNumber,
            title,
            baseLateFee,
            3,
            0.5m)
    {
    }
}
