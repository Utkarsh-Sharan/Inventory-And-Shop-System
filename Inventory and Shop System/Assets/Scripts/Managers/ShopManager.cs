using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager
{
    private Transform _shopPanel;
    private GameObject _shopItemPrefab;
    private List<ItemDataScriptableObject> _shopItemsSOList;
    private ShopController _shopController;
    private ShopView _shopView;
    
    public ShopManager(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItemsSOList, ShopController shopController, ShopView shopView)
    {
        _shopPanel = shopPanel;
        _shopItemPrefab = shopItemPrefab;
        _shopItemsSOList = shopItemsSOList;
        _shopController = shopController;
        _shopView = shopView;
    }

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, InventoryManager inventoryManager, AudioManager audioManager)
    {
        _shopController.Init(descriptionManager, currencyManager, weightManager, inventoryManager, audioManager);
        _shopController.Initialize(_shopPanel, _shopItemPrefab, _shopItemsSOList);

        _shopView.Init(_shopController);
    }

    public void AddItemToShop(ItemDataScriptableObject itemData)
    {
        _shopController.AddItemToShop(itemData);
    }
}
