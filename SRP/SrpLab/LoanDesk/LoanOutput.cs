namespace SrpLab;

public sealed class LoanOutput
{
    public IReadOnlyList<string> RequiredDocuments(LoanDesk loan)
    {
        var docs = new List<string>
        {
            "National ID",
            "Proof of income (3 months)"
        };

        if (loan.RequestedAmount > 40_000m)
            docs.Add("Bank statements (6 months)");

        if (loan.HasCollateral)
            docs.Add("Collateral ownership deed");

        if (loan.EmploymentMonths < 12)
            docs.Add("Employer letter");

        if (!loan.IsEligible())
            docs.Add("Manual underwriter referral form");

        return docs;
    }

    public string DecisionLetter(
        LoanDesk loan,
        string applicantName)
    {
        var risk = loan.RiskScore();
        var documents = RequiredDocuments(loan);

        if (loan.IsEligible())
        {
            return $"Dear {applicantName},\n" +
                   $"Your request for {loan.RequestedAmount:C} " +
                   $"is pre-approved (risk {risk:0}).\n" +
                   $"Please upload: {string.Join("; ", documents)}.\n";
        }

        return $"Dear {applicantName},\n" +
               $"We are unable to approve {loan.RequestedAmount:C} at this time.\n" +
               $"Reference risk={risk:0}. " +
               $"You may reapply after improving documentation.\n";
    }

    public string UnderwriterCsvRow(
        LoanDesk loan,
        string applicationId)
    {
        return $"{applicationId}," +
               $"{loan.CreditScore}," +
               $"{loan.EmploymentMonths}," +
               $"{(loan.HasCollateral ? 1 : 0)}," +
               $"{loan.RiskScore():0.00}," +
               $"{(loan.IsEligible() ? "Y" : "N")}";
    }
}
