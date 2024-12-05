public class WeightModel
{
    private float _initialWeight = 0f;
    private float _currentWeight;
    private float _weightLimit = 15f;

    public WeightModel()
    {
        _currentWeight = _initialWeight;
    }

    public void IncrementWeight(float value)
    {
        _currentWeight += value;
    }

    public void DecrementWeight(float value)
    {
        _currentWeight -= value;
    }

    public float GetCurrentWeight()
    {
        return _currentWeight;
    }

    public float GetRemainingWeight()
    {
        return (_weightLimit - _currentWeight);
    }
}
