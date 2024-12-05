using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers(or Services)")]
    [SerializeField] private DescriptionManager _descriptionManager;
    private ShopManager _shopManager;
    private InventoryManager _inventoryManager;
    private CurrencyManager _currencyManager;
    private WeightManager _weightManager;

    [Header("ShopManager fields")]
    [SerializeField] private Transform _shopPanel;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private List<ItemDataScriptableObject> _shopItems;
    [SerializeField] private ShopController _shopController;

    [Header("InventoryManager fields")]
    [SerializeField] private Transform _inventoryPanel;
    [SerializeField] private GameObject _inventoryItemPrefab;
    [SerializeField] private InventoryController _inventoryController;

    [Header("CurrencyManager fields")]
    [SerializeField] private CurrencyController _currencyController;

    [Header("WeightManager fields")]
    [SerializeField] private WeightController _weightController;

    private void Start()
    {
        CreateManagers();
        InjectDependencies();
    }

    private void CreateManagers()
    {
        _shopManager = new ShopManager(_shopPanel, _shopItemPrefab, _shopItems, _shopController);
        _currencyManager = new CurrencyManager(_currencyController);
        _weightManager = new WeightManager(_weightController);
        _inventoryManager = new InventoryManager(_inventoryPanel, _inventoryItemPrefab, _inventoryController);
    }

    private void InjectDependencies()
    {
        _shopManager.Init(_descriptionManager, _currencyManager, _weightManager, _inventoryManager);
        _inventoryManager.Init(_descriptionManager, _currencyManager, _weightManager);
    }
}
