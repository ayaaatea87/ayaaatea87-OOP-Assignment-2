namespace SrpLab;

public sealed class CourseInvoice
{
    public string Generate(
        CourseEnrollmentDesk enrollment,
        string studentEmail)
    {
        if (!enrollment.IsSeated(studentEmail))
            return $"{enrollment.CourseCode},WAITLIST,0.00";

        var vat = Math.Round(
            enrollment.Tuition * 0.14m,
            2);

        var total = enrollment.Tuition + vat;

        return $"{enrollment.CourseCode}," +
               $"TUITION,{enrollment.Tuition:0.00}," +
               $"VAT,{vat:0.00}," +
               $"TOTAL,{total:0.00}";
    }
}
