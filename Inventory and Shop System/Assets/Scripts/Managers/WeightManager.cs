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

    public void ItemSold(float value)
    {
        _weightController.ItemSold(value);
    }

    public float GetRemainingWeight()
    {
        return _weightController.GetRemainingWeight();
    }

    public bool CanAddWeight(float value)
    {
        return _weightController.CanAddWeight(value);
    }
}
