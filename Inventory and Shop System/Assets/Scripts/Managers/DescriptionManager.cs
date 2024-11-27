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
    [SerializeField] private TextMeshProUGUI _quantity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemDescription(string itemType, float buyingPrice, float sellingPrice, float weight, string itemRarity, int quantity)
    {
        _itemType.text = $"Type: {itemType}";
        _buyingPrice.text = $"Buying Price: {buyingPrice.ToString()}";
        _sellingPrice.text = $"Selling Price: {sellingPrice.ToString()}";
        _weight.text = $"Weight: {weight.ToString()}";
        _itemRarity.text = $"Rarity: {itemRarity}";
        _quantity.text = $"Quantity: {quantity.ToString()}";
    }
}
