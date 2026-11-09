namespace SrpLab;

public sealed class AppointmentReminder
{
    public string CreateSms(
        DateTimeOffset slot,
        string clinicPhone)
    {
        return $"Reminder: appointment {slot:MMM dd HH:mm}. " +
               $"Call {clinicPhone} to reschedule.";
    }
}
