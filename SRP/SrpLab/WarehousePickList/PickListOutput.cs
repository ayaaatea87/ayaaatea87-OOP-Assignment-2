namespace SrpLab;

public sealed class PickListOutput
{
    public string PickerScript(WarehousePickList pickList)
    {
        var steps = pickList
            .WalkingOrder()
            .Select((s, i) =>
                $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");

        var shortfalls = pickList
            .Allocate()
            .Where(a =>
            {
                var need = pickList.Lines
                    .First(l => l.Sku == a.Sku)
                    .QtyNeeded;

                return a.Allocated < need;
            });

        var warning = shortfalls.Any()
            ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
            : "SHORTAGES: none";

        return string.Join('\n', steps) + "\n" + warning;
    }

    public string WmsXmlBatch(
        WarehousePickList pickList,
        string batchId)
    {
        var parts = pickList
            .Allocate()
            .Select(a =>
                $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");

        return $"<batch id=\"{batchId}\">{string.Join("", parts)}</batch>";
    }
}