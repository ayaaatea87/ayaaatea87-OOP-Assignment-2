namespace SrpLab;

public sealed class AppointmentIcsExporter
{
    public string ToIcs(
        DateTimeOffset slot,
        string patientName,
        string clinician,
        int slotMinutes)
    {
        var uid = Guid.NewGuid();
        var end = slot.AddMinutes(slotMinutes);

        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\n" +
               $"DTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"DTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\n" +
               "END:VEVENT\nEND:VCALENDAR\n";
    }
}
