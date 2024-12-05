using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers(or Services)")]
    [SerializeField] private DescriptionManager _descriptionManager;
    private ShopManager _shopManager;
    private CurrencyManager _currencyManager;
    private WeightManager _weightManager;

    [Header("ShopManager fields")]
    [SerializeField] private Transform _shopPanel;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private List<ItemDataScriptableObject> _shopItems;
    [SerializeField] private ShopController _shopController;

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
    }

    private void InjectDependencies()
    {
        _shopManager.Init(_descriptionManager, _currencyManager, _weightManager);
    }
}
