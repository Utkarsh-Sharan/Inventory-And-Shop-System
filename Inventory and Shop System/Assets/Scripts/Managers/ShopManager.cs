using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Transform _shopPanel;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private List<ItemDataScriptableObject> _shopItems;
    [SerializeField] private DescriptionManager _descriptionManager;

    private void Start()
    {
        PopulateShop();
    }

    private void PopulateShop()
    {
        foreach (var itemData in _shopItems)
        {
            var shopItem = Instantiate(_shopItemPrefab, _shopPanel);
            ShopController controller = shopItem.GetComponent<ShopController>();
            controller.Initialize(itemData, _descriptionManager);
        }
    }
}
