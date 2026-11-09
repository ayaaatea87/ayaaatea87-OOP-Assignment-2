namespace SrpLab;

public sealed class TicketSlaService
{
    public DateTimeOffset SlaDeadline(
        SupportTicket ticket)
    {
        var hours = ticket.Priority switch
        {
            "P1" => 4,
            "P2" => 24,
            _ => 72
        };

        return ticket.OpenedAt.AddHours(hours);
    }

    public bool IsBreached(
        SupportTicket ticket,
        DateTimeOffset now)
    {
        return now > SlaDeadline(ticket);
    }

    public string DraftPublicReply(
        SupportTicket ticket,
        string agentName)
    {
        var deadline = SlaDeadline(ticket);

        var message = ticket.Priority == "P1"
            ? "We are treating this as a critical incident."
            : "Thanks for reaching out.";

        return $"Hi,\n{message}\n" +
               $"Ticket {ticket.Id} is with {agentName}. " +
               $"Next update before {deadline:u}.\n";
    }

    public string InternalEscalationBlurb(
        SupportTicket ticket)
    {
        var deadline = SlaDeadline(ticket);

        return $"ESCALATE {ticket.Id} " +
               $"priority={ticket.Priority} " +
               $"breachAt={deadline:u} " +
               "keywords-scanned=yes";
    }
}
