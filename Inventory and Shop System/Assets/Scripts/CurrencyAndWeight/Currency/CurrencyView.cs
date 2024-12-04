using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currencyText;
    private CurrencyController _currencyController;

    public void SetController(CurrencyController currencyController)
    {
        _currencyController = currencyController;
    }

    public void UpdateCurrency()
    {
        _currencyText.text = $"Currency left : {_currencyController.GetCurrencyModel().GetCurrentCurrency()} Units";
    }
}
