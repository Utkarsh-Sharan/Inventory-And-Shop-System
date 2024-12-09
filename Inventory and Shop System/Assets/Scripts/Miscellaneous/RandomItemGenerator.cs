using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    private List<ItemDataScriptableObject> _shopItems;

    public void Initialize(InventoryManager inventoryManager, List<ItemDataScriptableObject> shopItems)
    {
        _inventoryManager = inventoryManager;
        _shopItems = shopItems;
    }

    public void OnGenerateItemsButtonCLick()
    {
        _inventoryManager.GenerateRandomItems(_shopItems);
    }
}
