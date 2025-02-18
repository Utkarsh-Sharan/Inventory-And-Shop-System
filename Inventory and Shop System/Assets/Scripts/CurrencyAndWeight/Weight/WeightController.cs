using System;
using TMPro;
using UnityEngine;

public class WeightController : MonoBehaviour
{
    private const float _EPSILON = 1e-6f;

    [SerializeField] private TextMeshProUGUI _weightText;

    private float _initialWeight = 0f;
    private float _currentWeight;
    private float _weightLimit = 15f;

    public void Initialize()
    {
        _currentWeight = _initialWeight;
        UpdateWeight();
    }

    public void ItemPurchased(float value)
    {
        _currentWeight += value;

        if (_currentWeight > _weightLimit)
        {
            _currentWeight = _weightLimit;
        }

        UpdateWeight();
    }

    public void ItemSold(float value)
    {
        _currentWeight -= value;

        if (_currentWeight <= 0f)
        {
            _currentWeight = 0f;
        }

        UpdateWeight();
    }

    public float GetRemainingWeight() => (_weightLimit - _currentWeight);

    public bool CanAddWeight(float value) => GetCurrentWeight() + value <= _weightLimit;

    public void UpdateWeight() => _weightText.text = $"Current weight : {GetCurrentWeight()} kg";

    public float GetCurrentWeight() => Math.Abs(_currentWeight) < _EPSILON ? 0 : _currentWeight;
}
