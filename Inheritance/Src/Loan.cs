namespace Inheritance;

public enum LoanStatus
{
    Borrowed,
    Returned,
    Lost
}


public class Loan
{
    public string LoanId { get; }
    public DateTime BorrowDate { get; }

    public DateTime DueDate
    {
        get
        {
            return BorrowDate.AddDays(Item.LoanPeriodDays);
        }
    }

    public Member Member { get; }
    public LibraryItem Item { get; }

    public LoanStatus Status { get; private set; }

    public DateTime? ReturnDate { get; private set; }

    public decimal LateFee
    {
        get
        {
            if (ReturnDate == null)
                return 0;

            if (ReturnDate.Value <= DueDate)
                return 0;

            int lateDays =
                (ReturnDate.Value.Date - DueDate.Date).Days;

            decimal fee =
                lateDays * Item.DailyLateFee;

            decimal discount =
                fee * Member.DiscountPercentage / 100;

            return fee - discount;
        }
    }

    public Loan(
        string loanId,
        DateTime borrowDate,
        Member member,
        LibraryItem item)
    {
        if (string.IsNullOrEmpty(loanId))
            throw new Exception("Loan ID cannot be empty.");

        LoanId = loanId;
        BorrowDate = borrowDate;
        Member = member;
        Item = item;
        Status = LoanStatus.Borrowed;
    }

    public void Return(DateTime returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new Exception("Only a borrowed loan can be returned.");

        if (returnDate < BorrowDate)
            throw new Exception(
                "Return date cannot be earlier than borrow date.");

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;

        Item.MarkAsReturned();
    }

    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new Exception(
                "Only a borrowed loan can be marked as lost.");

        Status = LoanStatus.Lost;

        Item.MarkAsReturned();
    }
}
