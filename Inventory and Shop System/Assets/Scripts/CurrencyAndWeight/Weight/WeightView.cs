using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeightView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _weightText;
    private WeightController _weightController;

    public void SetController(WeightController weightController)
    {
        _weightController = weightController;
    }

    public void UpdateWeight()
    {
        _weightText.text = $"Current weight : {_weightController.GetWeightModel().GetCurrentWeight()} kg";
    }
}
