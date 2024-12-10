using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopController : MonoBehaviour
{
    private Dictionary<(ItemType, ItemRarity), ShopModel> _shopItems = new();
    private Dictionary<(ItemType, ItemRarity), ShopItem> _shopItemsQuantityUI = new();

    private ShopModel _shopModel;

    private DescriptionManager _descriptionManager;
    private CurrencyManager _currencyManager;
    private WeightManager _weightManager;
    private InventoryManager _inventoryManager;
    private AudioManager _audioManager;

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, InventoryManager inventoryManager, AudioManager audioManager)
    {
        _descriptionManager = descriptionManager;
        _currencyManager = currencyManager;
        _weightManager = weightManager;
        _inventoryManager = inventoryManager;
        _audioManager = audioManager;
    }

    public void Initialize(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems)
    {
        foreach(var itemData in shopItems )
        {
            var key = (itemData.itemType, itemData.itemRarity);

            var shopItemObject = Instantiate(shopItemPrefab, shopPanel);
            ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();
            ShopModel shopModel = new ShopModel(itemData);

            _shopItems[key] = shopModel;
            _shopItemsQuantityUI[key] = shopItem;

            shopItem.SetShopController(this);
            shopItem.Initialize(shopModel);
        }
    }

    public void DescribeItem(ShopItem shopItem)
    {
        _audioManager.PlaySound(AudioType.ITEM_HOVER);

        ShopModel model = shopItem.GetShopModel();

        _descriptionManager.ItemDescription
        (
            model.GetItemType(),
            model.ItemDataSO.buyingPrice,
            model.ItemDataSO.sellingPrice,
            model.ItemDataSO.weight,
            model.GetItemRarity()
        );
    }

    public void RestockShopItem(ItemDataScriptableObject itemData)
    {
        var key = (itemData.itemType, itemData.itemRarity);

        if(_shopItems.TryGetValue(key, out ShopModel model))
        {
            model.IncreaseItemQuantity();
            _shopItemsQuantityUI[key].DisplayItemQuantity();
        }
    }

    public void PurchaseItem(ShopItem shopItem)
    {
        var model = shopItem.GetShopModel();

        if(IsItemPurchasable(model) && IsItemAvailable(model) && IsItemWeightInLimit(model))
        {
            _audioManager.PlaySound(AudioType.ITEM_CLICKED);
            _currencyManager.ItemPurchased(model.ItemDataSO.buyingPrice);
            _weightManager.ItemPurchased(model.ItemDataSO.weight);

            model.DecreaseItemQuantity();
            shopItem.DisplayItemQuantity();

            _inventoryManager.AddItemToInventory(model.ItemDataSO);
        }
        else
        {
            _audioManager.PlaySound(AudioType.ERROR);
        }
    }

    private bool IsItemPurchasable(ShopModel model)
    {
        return model.ItemDataSO.buyingPrice <= _currencyManager.GetCurrentCurrency();
    }

    private bool IsItemAvailable(ShopModel model)
    {
        return model.GetItemQuantity() > 0;
    }

    private bool IsItemWeightInLimit(ShopModel model)
    {
        return model.ItemDataSO.weight <= _weightManager.GetRemainingWeight();
    }
}
