using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager
{
    private Transform _shopPanel;
    private GameObject _shopItemPrefab;
    private List<ItemDataScriptableObject> _shopItems;
    private ShopPopulator _shopPopulator;
    
    //Dependencies
    private DescriptionManager _descriptionManager;

    public ShopManager(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems, ShopPopulator shopPopulator)
    {
        _shopPanel = shopPanel;
        _shopItemPrefab = shopItemPrefab;
        _shopItems = shopItems;
        _shopPopulator = shopPopulator;
    }

    public void Init(DescriptionManager descriptionManager)
    {
        _descriptionManager = descriptionManager;
        _shopPopulator.PopulateShop(_shopPanel, _shopItemPrefab, _shopItems, _descriptionManager);
    }
}
