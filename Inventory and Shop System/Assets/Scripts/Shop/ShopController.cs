using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopController : MonoBehaviour
{
    private ShopModel _shopModel;
    private DescriptionManager _descriptionManager;
    private CurrencyManager _currencyManager;
    private WeightManager _weightManager;
    private InventoryManager _inventoryManager;

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, InventoryManager inventoryManager)
    {
        _descriptionManager = descriptionManager;
        _currencyManager = currencyManager;
        _weightManager = weightManager;
        _inventoryManager = inventoryManager;
    }

    public void Initialize(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems)
    {
        foreach(var itemData in shopItems )
        {
            var shopItemObject = Instantiate(shopItemPrefab, shopPanel);
            ShopItem shopItem = shopItemObject.GetComponent<ShopItem>();
            ShopModel shopModel = new ShopModel(itemData);

            shopItem.SetShopController(this);
            shopItem.Initialize(shopModel);
        }
    }

    public void DescribeItem(ShopItem shopItem)
    {
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

    public void PurchaseItem(ShopItem shopItem)
    {
        var model = shopItem.GetShopModel();

        if(IsItemPurchasable(model) && IsItemAvailable(model) && IsItemWeightInLimit(model))
        {
            _currencyManager.ItemPurchased(model.ItemDataSO.buyingPrice);
            _weightManager.ItemPurchased(model.ItemDataSO.weight);
            model.DecreaseItemQuantity();
            shopItem.DisplayItemQuantity();

            _inventoryManager.AddItemToInventory(model.ItemDataSO);
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

    public void IncreaseItemQuantity(ItemDataScriptableObject itemData)
    {
        
    }
}
