using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers(or Services)")]
    private ShopManager _shopManager;
    [SerializeField] private DescriptionManager _descriptionManager;

    [Header("ShopManager fields")]
    [SerializeField] private Transform _shopPanel;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private List<ItemDataScriptableObject> _shopItems;
    [SerializeField] private ShopPopulator _shopPopulator;

    private void Start()
    {
        CreateManagers();
        InjectDependencies();
    }

    private void CreateManagers()
    {
        _shopManager = new ShopManager(_shopPanel, _shopItemPrefab, _shopItems, _shopPopulator);
    }

    private void InjectDependencies()
    {
        _shopManager.Init(_descriptionManager);
    }
}
