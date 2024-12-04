using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    [SerializeField] private CurrencyView _currencyView;
    private CurrencyModel _currencyModel;

    public void Initialize()
    {
        _currencyModel = new CurrencyModel();
        _currencyView.SetController(this);
        _currencyView.UpdateCurrency();
    }

    public void ItemPurchased(float value)
    {
        _currencyModel.DecrementCurrency(value);
        _currencyView.UpdateCurrency();
    }

    public CurrencyModel GetCurrencyModel()
    {
        return _currencyModel;
    }

    public float GetCurrentCurrency()
    {
        return _currencyModel.GetCurrentCurrency();
    }
}
