namespace SrpLab;

public sealed class WarehousePickList
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();

    public void AddNeed(
        string sku,
        string aisle,
        int bin,
        int qtyNeeded,
        int qtyOnHand)
    {
        _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        return _lines
            .Select(line =>
                (line.Sku, Allocated: Math.Min(line.QtyNeeded, line.QtyOnHand)))
            .ToList();
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
        return _lines
            .OrderBy(line => line.Aisle)
            .ThenBy(line => line.Bin)
            .Select(line =>
                (line.Aisle,
                 line.Bin,
                 line.Sku,
                 Qty: Math.Min(line.QtyNeeded, line.QtyOnHand)))
            .Where(x => x.Qty > 0)
            .ToList();
    }

    public IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> Lines
        => _lines;
}