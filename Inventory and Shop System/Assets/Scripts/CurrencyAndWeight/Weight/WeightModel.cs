using System;

public class WeightModel
{
    private float _initialWeight = 0f;
    private float _currentWeight;
    private float _weightLimit = 15f;

    private const float Epsilon = 1e-6f;

    public WeightModel()
    {
        _currentWeight = _initialWeight;
    }

    public void IncrementWeight(float value)
    {
        _currentWeight += value;

        if(_currentWeight > _weightLimit)
        {
            _currentWeight = _weightLimit;
        }
    }

    public void DecrementWeight(float value)
    {
        _currentWeight -= value;

        if (_currentWeight <= 0f)
        {
            _currentWeight = 0f;
        }
    }

    public float GetCurrentWeight()
    {
        return Math.Abs(_currentWeight) < Epsilon ? 0 : _currentWeight;
    }

    public float GetRemainingWeight()
    {
        return (_weightLimit - _currentWeight);
    }

    public float GetWeightLimit()
    {
        return _weightLimit;
    }
}
