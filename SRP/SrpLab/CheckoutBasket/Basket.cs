namespace SrpLab;

public sealed class Basket
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
    private bool _giftWrap;

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0)
            throw new ArgumentOutOfRangeException(nameof(qty));

        _lines.Add((sku, price, qty));
    }

    public void EnableGiftWrap()
    {
        _giftWrap = true;
    }

    public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;

    public decimal SubTotal()
    {
        return _lines.Sum(l => l.Price * l.Qty);
    }

    public bool IsGiftWrapped => _giftWrap;
}
