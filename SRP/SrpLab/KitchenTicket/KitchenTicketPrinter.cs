namespace SrpLab;

public sealed class KitchenTicketPrinter
{
    public string RenderThermalTicket(
        KitchenTicket ticket,
        KitchenOperations operations,
        int orderNumber)
    {
        var width = 32;
        var line = new string('=', width);

        var body = string.Join(
            '\n',
            ticket.Items.Select(i =>
                $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));

        var allergens = operations.DetectAllergens(ticket);

        var allergyLine = allergens.Count == 0
            ? "ALLERGENS: none"
            : "ALLERGENS: " + string.Join(",", allergens);

        var eta = operations.EstimatedReadyMinutes(ticket, 2);

        return $"{line}\n" +
               $"ORDER #{orderNumber}\n" +
               $"ETA {eta} MIN\n" +
               $"{body}\n" +
               $"{allergyLine}\n" +
               $"{line}\n";
    }
}
