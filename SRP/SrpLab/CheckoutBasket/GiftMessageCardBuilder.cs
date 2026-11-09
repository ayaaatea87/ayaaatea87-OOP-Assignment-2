namespace SrpLab;

public sealed class GiftMessageCardBuilder
{
    public string Build(
        string fromName,
        IReadOnlyList<(string Sku, decimal Price, int Qty)> lines,
        decimal total)
    {
        var items = string.Join(", ", lines.Select(l => l.Sku));

        return $"Dear friend,\n" +
               $"A gift from {fromName} awaits ({items}).\n" +
               $"Total surprise value: {total:C}\n";
    }
}
