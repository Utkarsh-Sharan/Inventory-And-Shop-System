using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private Transform _inventoryPanel;
    private GameObject _inventoryItemPrefab;
    private InventoryController _inventoryController;

    public InventoryManager(Transform inventoryPanel, GameObject inventoryItemPrefab, InventoryController inventoryController)
    {
        _inventoryPanel = inventoryPanel;
        _inventoryItemPrefab = inventoryItemPrefab;
        _inventoryController = inventoryController;
    }

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, ShopManager shopManager)
    {
        _inventoryController.Init(descriptionManager, currencyManager, weightManager, shopManager);
        _inventoryController.Initialize(_inventoryPanel, _inventoryItemPrefab);
    }

    public void GenerateRandomItems(List<ItemDataScriptableObject> availableItems)
    {
        _inventoryController.GenerateRandomItems(availableItems);
    }

    public void AddItemToInventory(ItemDataScriptableObject itemData)
    {
        _inventoryController.AddItemToInventory(itemData);
    }
}
