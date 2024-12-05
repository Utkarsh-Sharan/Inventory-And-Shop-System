public class WeightManager
{
    private WeightController _weightController;

    public WeightManager(WeightController weightController)
    {
        _weightController = weightController;
        _weightController.Initialize();
    }

    public void ItemPurchased(float value)
    {
        _weightController.ItemPurchased(value);
    }

    public float GetRemainingWeight()
    {
        return _weightController.GetRemainingWeight();
    }
}
