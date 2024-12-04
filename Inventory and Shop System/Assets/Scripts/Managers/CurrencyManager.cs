public class CurrencyManager
{
    private CurrencyController _currencyController;

    public CurrencyManager(CurrencyController currencyController)
    {
        _currencyController = currencyController;
        _currencyController.Initialize();
    }

    public void ItemPurchased(float value)
    {
        _currencyController.ItemPurchased(value);
    }

    public float GetCurrentCurrency()
    {
        return _currencyController.GetCurrentCurrency();
    }
}
