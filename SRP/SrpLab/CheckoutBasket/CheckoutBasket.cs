namespace SrpLab;

public sealed class CheckoutBasket
{
    private readonly Basket _basket = new();
    private readonly CouponDiscount _discountCalculator = new();
    private readonly GiftMessageCardBuilder _giftMessageBuilder = new();
    private readonly PaymentAuthorizer _paymentAuthorizer = new();

    private string? _couponRaw;

    public void AddLine(string sku, decimal price, int qty)
    {
        _basket.AddLine(sku, price, qty);
    }

    public void ApplyCouponText(string? couponText)
    {
        _couponRaw = couponText;
    }

    public void EnableGiftWrap()
    {
        _basket.EnableGiftWrap();
    }

    public decimal SubTotal()
    {
        return _basket.SubTotal();
    }

    public decimal DiscountAmount()
    {
        return _discountCalculator.Calculate(
            _couponRaw,
            SubTotal());
    }

    public decimal GrandTotal()
    {
        var total = SubTotal() - DiscountAmount();

        if (_basket.IsGiftWrapped)
            total += 4.99m;

        return Math.Max(0m, total);
    }

    public string GiftMessageCard(string fromName)
    {
        return _giftMessageBuilder.Build(
            fromName,
            _basket.Lines,
            GrandTotal());
    }

    public string AuthorizePaymentStub(string cardLast4)
    {
        return _paymentAuthorizer.Authorize(
            GrandTotal(),
            cardLast4,
            _basket.Lines.Count);
    }
}
