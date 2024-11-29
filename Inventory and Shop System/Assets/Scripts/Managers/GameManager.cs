using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ShopManager _shopManager;
    private DescriptionManager _descriptionManager;

    [SerializeField] private Transform _shopPanel;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private List<ItemDataScriptableObject> _shopItems;

    private void Start()
    {
        CreateManagers();
        InjectDependencies();
    }

    private void CreateManagers()
    {
        _shopManager = new ShopManager(_shopPanel, _shopItemPrefab, _shopItems);
        _descriptionManager = new DescriptionManager();
    }

    private void InjectDependencies()
    {
        _shopManager.Init(_descriptionManager);
    }
}
