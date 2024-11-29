using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private Transform _shopPanel;
    private GameObject _shopItemPrefab;
    private List<ItemDataScriptableObject> _shopItems;
    //[SerializeField] private DescriptionManager _descriptionManager;
    private DescriptionManager _descriptionManager;

    public ShopManager(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems)
    {
        _shopPanel = shopPanel;
        _shopItemPrefab = shopItemPrefab;
        _shopItems = shopItems;
    }

    public void Init(DescriptionManager descriptionManager)
    {
        _descriptionManager = descriptionManager; 
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
