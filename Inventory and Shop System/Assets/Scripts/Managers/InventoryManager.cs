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

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager)
    {
        _inventoryController.Init(descriptionManager, currencyManager, weightManager);
        _inventoryController.Initialize(_inventoryPanel, _inventoryItemPrefab);
    }
}
