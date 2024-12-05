using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Dictionary<(ItemType, ItemRarity), InventoryModel> _inventoryItems = new();
    private Transform _inventoryPanel;
    private GameObject _inventoryItemPrefab;

    public void Initialize(Transform inventoryPanel, GameObject inventoryItemPrefab)
    {
        _inventoryPanel = inventoryPanel;
        _inventoryItemPrefab = inventoryItemPrefab;
    }

    public void AddItemToInventory(ItemDataScriptableObject itemData)
    {
        var key = (itemData.itemType, itemData.itemRarity);

        if(_inventoryItems.TryGetValue(key, out InventoryModel model))  //if item already present in inventory, just increase its quantity
        {
            model.IncreaseItemQuantity();
        }
        else                                                            //else add item to the inventory
        {
            InventoryModel newModel = new InventoryModel(itemData);
            _inventoryItems[key] = newModel;

            var inventoryItemObject = Instantiate(_inventoryItemPrefab, _inventoryPanel);
            InventoryItem inventoryItem = inventoryItemObject.GetComponent<InventoryItem>();
            inventoryItem.Initialize(newModel, this);
        }
    }

    public void RemoveItemFromInventory(InventoryItem inventoryItem)
    {
        InventoryModel model = inventoryItem.GetInventoryModel();
        var key = (model.ItemDataSO.itemType, model.ItemDataSO.itemRarity);

        if(model.DecreaseItemQuantity() <= 0)       //if only 1 item present, remove it from the list and destroy the item
        {
            _inventoryItems.Remove(key);
            Destroy(inventoryItem.gameObject);
        }
        else
        {
            inventoryItem.UpdateItemQuantity();     //else update its quantity
        }
    }
}
