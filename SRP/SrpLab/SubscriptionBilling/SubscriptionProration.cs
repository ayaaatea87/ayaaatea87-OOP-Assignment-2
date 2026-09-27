namespace SrpLab;

public sealed class SubscriptionProration
{
    public decimal Calculate(
        SubscriptionBilling billing,
        DateOnly activeFrom)
    {
        if (activeFrom <= billing.PeriodStart)
            return billing.MonthlyPrice;

        if (activeFrom >= billing.PeriodEnd)
            return 0m;

        var totalDays =
            billing.PeriodEnd.DayNumber -
            billing.PeriodStart.DayNumber;

        if (totalDays <= 0)
            return billing.MonthlyPrice;

        var used =
            billing.PeriodEnd.DayNumber -
            activeFrom.DayNumber;

        return Math.Round(
            billing.MonthlyPrice * used / totalDays,
            2);
    }
}
