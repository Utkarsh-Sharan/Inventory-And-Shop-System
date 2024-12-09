public class CurrencyModel
{
    private float _initialCurrency = 0f;
    private float _currentCurrency;

    public CurrencyModel()
    {
        _currentCurrency = _initialCurrency;
    }

    public void IncrementCurrency(float value)
    {
        _currentCurrency += value;
    }

    public void DecrementCurrency(float value)
    {
        _currentCurrency -= value;
    }

    public float GetCurrentCurrency()
    {
        return _currentCurrency;
    }
}
