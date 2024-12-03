using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DescriptionManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _itemType;
    [SerializeField] private TextMeshProUGUI _buyingPrice;
    [SerializeField] private TextMeshProUGUI _sellingPrice;
    [SerializeField] private TextMeshProUGUI _weight;
    [SerializeField] private TextMeshProUGUI _itemRarity;

    public void ItemDescription(string itemType, float buyingPrice, float sellingPrice, float weight, string itemRarity)
    {
        _itemType.text = $"Type: {itemType}";
        _buyingPrice.text = $"Buying Price: {buyingPrice.ToString()}";
        _sellingPrice.text = $"Selling Price: {sellingPrice.ToString()}";
        _weight.text = $"Weight: {weight.ToString()}";
        _itemRarity.text = $"Rarity: {itemRarity}";
    }
}
