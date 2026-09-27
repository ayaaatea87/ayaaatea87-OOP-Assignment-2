namespace SrpLab;

public sealed class SubscriptionOutput
{
    private static int _invoiceSeq = 1000;

    public string NextInvoiceNumber(DateOnly periodStart)
    {
        var number = ++_invoiceSeq;

        return $"INV-{periodStart:yyyyMM}-{number:D5}";
    }

    public string DunningEmail(
        SubscriptionBilling billing,
        SubscriptionProration proration,
        string customerName,
        DateOnly asOf)
    {
        var amount = proration.Calculate(
            billing,
            billing.PeriodStart);

        var invoice = NextInvoiceNumber(billing.PeriodStart);

        var severity = billing.FailedPayments switch
        {
            <= 1 => "friendly reminder",
            2 => "second notice",
            _ => "final notice before suspension"
        };

        return $"Subject: {severity} {invoice}\n" +
               $"Hi {customerName},\n" +
               $"Balance {amount:C} as of {asOf:o} " +
               $"({billing.FailedPayments} failures).\n";
    }

    public string LedgerJournalLine(
        SubscriptionBilling billing,
        SubscriptionProration proration,
        DateOnly activeFrom)
    {
        var amount = proration.Calculate(
            billing,
            activeFrom);

        return $"{billing.CustomerId}," +
               $"{NextInvoiceNumber(billing.PeriodStart)}," +
               $"{amount:0.00},AR-SUB";
    }
}