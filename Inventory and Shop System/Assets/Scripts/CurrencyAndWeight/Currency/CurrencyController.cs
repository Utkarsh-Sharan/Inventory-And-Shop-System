using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyText;
    private float _initialCurrency = 0f;
    private float _currentCurrency;

    public void Initialize()
    {
        _currentCurrency = _initialCurrency;
        UpdateCurrency();
    }

    public void ItemPurchased(float value)
    {
        _currentCurrency -= value;
        UpdateCurrency();
    }

    public void ItemSold(float value)
    {
        _currentCurrency += value;
        UpdateCurrency();
    }

    public void UpdateCurrency()
    {
        _currencyText.text = $"Currency left : {GetCurrentCurrency()} Units";
    }

    public float GetCurrentCurrency()
    {
        return _currentCurrency;
    }
}
