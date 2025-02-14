using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private Dictionary<(ItemType, ItemRarity), InventoryModel> _inventoryItems = new();
    private Dictionary<(ItemType, ItemRarity), InventoryItem> _inventoryItemsQuantityUI = new();

    private Transform _inventoryPanel;
    private GameObject _inventoryItemPrefab;

    private DescriptionManager _descriptionManager;
    private CurrencyManager _currencyManager;
    private WeightManager _weightManager;
    private ShopManager _shopManager;
    private AudioManager _audioManager;

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, ShopManager shopManager, AudioManager audioManager)
    {
        _audioManager = audioManager;
        _descriptionManager = descriptionManager;
        _currencyManager = currencyManager;
        _weightManager = weightManager;
        _shopManager = shopManager;
    }

    public void Initialize(Transform inventoryPanel, GameObject inventoryItemPrefab)
    {
        _inventoryPanel = inventoryPanel;
        _inventoryItemPrefab = inventoryItemPrefab;
    }

    public void DescribeItem(InventoryItem inventoryItem)
    {
        _audioManager.PlaySound(AudioType.ITEM_HOVER);

        InventoryModel model = inventoryItem.GetModel();

        _descriptionManager.ItemDescription
        (
            model.GetItemType(),
            model.ItemDataSO.buyingPrice,
            model.ItemDataSO.sellingPrice,
            model.ItemDataSO.weight,
            model.GetItemRarity()
        );
    }

    public void GenerateRandomItems(List<ItemDataScriptableObject> availableItems, int minItems = 4, int maxItems = 5)
    {
        int itemCount = Random.Range(minItems, maxItems + 1);

        for (int i = 0; i < itemCount; ++i)
        {
            var randomItem = availableItems[Random.Range(0, availableItems.Count)];
            float weight = randomItem.weight;

            if (_weightManager.CanAddWeight(weight))
            {
                AddItemToInventory(randomItem);
                _weightManager.ItemPurchased(weight);
            }
        }
    }

    public void AddItemToInventory(ItemDataScriptableObject itemData)
    {
        var key = (itemData.itemType, itemData.itemRarity);

        if(_inventoryItems.TryGetValue(key, out InventoryModel model))  //if item already present in inventory, just increase its quantity
        {
            model.IncreaseItemQuantity();
            _inventoryItemsQuantityUI[key].UpdateItemQuantity(model);
        }
        else                                                            //else add item to the inventory
        {
            InventoryModel newModel = new InventoryModel(itemData);
            _inventoryItems[key] = newModel;

            var inventoryItemObject = Instantiate(_inventoryItemPrefab, _inventoryPanel);
            InventoryItem inventoryItem = inventoryItemObject.GetComponent<InventoryItem>();
            inventoryItem.Initialize(newModel, this);

            _inventoryItemsQuantityUI[key] = inventoryItem;
        }
    }

    public void SellItem(InventoryItem inventoryItem)
    {
        _audioManager.PlaySound(AudioType.ITEM_CLICKED);
        InventoryModel model = inventoryItem.GetModel();
        var key = (model.ItemDataSO.itemType, model.ItemDataSO.itemRarity);

        if(model.DecreaseItemQuantity() <= 0)       //if only 1 item present, remove it from the list and destroy the item
        {
            _inventoryItems.Remove(key);
            _inventoryItemsQuantityUI.Remove(key);

            Destroy(inventoryItem.gameObject);
        }
        else
        {
            inventoryItem.UpdateItemQuantity(model);     //else update its quantity
        }

        _currencyManager.ItemSold(model.ItemDataSO.sellingPrice);
        _weightManager.ItemSold(model.ItemDataSO.weight);
        _shopManager.ItemSold(model.ItemDataSO);
    }
}
