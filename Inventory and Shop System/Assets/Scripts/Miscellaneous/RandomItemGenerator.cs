using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    private List<ItemDataScriptableObject> _shopItems;
    private AudioManager _audioManager;

    public void Initialize(InventoryManager inventoryManager, List<ItemDataScriptableObject> shopItems, AudioManager audioManager)
    {
        _audioManager = audioManager;
        _inventoryManager = inventoryManager;
        _shopItems = shopItems;
    }

    public void OnGenerateItemsButtonCLick()
    {
        _audioManager.PlaySound(AudioType.GENERATE_ITEM);
        _inventoryManager.GenerateRandomItems(_shopItems);
    }
}
