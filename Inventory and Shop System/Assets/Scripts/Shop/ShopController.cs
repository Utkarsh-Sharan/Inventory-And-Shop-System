using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopController : TradeController
{
    private Dictionary<(ItemType, ItemRarity), ShopModel> _shopItems = new();
    private Dictionary<(ItemType, ItemRarity), ShopItem> _shopItemsQuantityUI = new();

    private InventoryManager _inventoryManager;

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, InventoryManager inventoryManager, AudioManager audioManager)
    {
        base.Init(descriptionManager, currencyManager, weightManager, audioManager);
        _inventoryManager = inventoryManager;
    }

    public void Initialize(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems)
    {
        foreach(var itemData in shopItems)
        {
            var key = (itemData.itemType, itemData.itemRarity);

            var shopItemObject = Instantiate(shopItemPrefab, shopPanel);
            ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();
            ShopModel shopModel = new ShopModel(itemData);

            _shopItems[key] = shopModel;
            _shopItemsQuantityUI[key] = shopItem;

            shopItem.Initialize(shopModel, this);
        }
    }

    public void RestockShopItem(ItemDataScriptableObject itemData)
    {
        var key = (itemData.itemType, itemData.itemRarity);

        if(_shopItems.TryGetValue(key, out ShopModel model))
        {
            model.IncreaseItemQuantity();
            _shopItemsQuantityUI[key].UpdateItemQuantity(model);
        }
    }

    public void PurchaseItem(ShopItem shopItem)
    {
        var model = shopItem.GetModel();

        if(IsItemPurchasable(model) && IsItemAvailable(model) && IsItemWeightInLimit(model))
        {
            audioManager.PlaySound(AudioType.ITEM_CLICKED);
            UpdateCurrencyAndWeight(model);

            model.DecreaseItemQuantity();
            shopItem.UpdateItemQuantity(model);

            _inventoryManager.AddItemToInventory(model.ItemDataSO);
        }
        else
        {
            audioManager.PlaySound(AudioType.ERROR);
        }
    }

    private bool IsItemPurchasable(ShopModel model) => (model.ItemDataSO.buyingPrice <= currencyManager.GetCurrentCurrency());

    private bool IsItemAvailable(ShopModel model) => (model.GetItemQuantity() > 0);

    private bool IsItemWeightInLimit(ShopModel model) => (model.ItemDataSO.weight <= weightManager.GetRemainingWeight());

    public Dictionary<(ItemType, ItemRarity), ShopItem> GetShopItems() => _shopItemsQuantityUI;
}