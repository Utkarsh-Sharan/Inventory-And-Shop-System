using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightController : MonoBehaviour
{
    [SerializeField] private WeightView _weightView;
    private WeightModel _weightModel;

    public void Initialize()
    {
        _weightModel = new WeightModel();
        _weightView.SetController(this);
        _weightView.UpdateWeight();
    }

    public void ItemPurchased(float value)
    {
        _weightModel.IncrementWeight(value);
        _weightView.UpdateWeight();
    }

    public void ItemSold(float value)
    {
        _weightModel.DecrementWeight(value);
        _weightView.UpdateWeight();
    }

    public WeightModel GetWeightModel()
    {
        return _weightModel;
    }

    public float GetRemainingWeight()
    {
        return _weightModel.GetRemainingWeight();
    }
}
