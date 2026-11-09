namespace SrpLab;

public sealed class CourseWelcomePacket
{
    public string Generate(
        CourseEnrollmentDesk enrollment,
        string studentEmail,
        string studentName)
    {
        var status = enrollment.IsSeated(studentEmail)
            ? "confirmed seat"
            : $"waitlist #{enrollment.WaitlistPosition(studentEmail)}";

        return $"# Welcome to {enrollment.CourseCode}\n" +
               $"Hi {studentName},\n" +
               $"Your status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: " +
               $"https://example.invalid/" +
               $"{enrollment.CourseCode.ToLowerInvariant()}\n";
    }
}
