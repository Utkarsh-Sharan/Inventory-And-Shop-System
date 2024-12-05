using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager
{
    private Transform _shopPanel;
    private GameObject _shopItemPrefab;
    private List<ItemDataScriptableObject> _shopItems;
    private ShopController _shopController;
    
    public ShopManager(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems, ShopController shopController)
    {
        _shopPanel = shopPanel;
        _shopItemPrefab = shopItemPrefab;
        _shopItems = shopItems;
        _shopController = shopController;
    }

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, InventoryManager inventoryManager)
    {
        _shopController.Init(descriptionManager, currencyManager, weightManager, inventoryManager);
        _shopController.Initialize(_shopPanel, _shopItemPrefab, _shopItems);
    }
}
