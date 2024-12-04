using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopController : MonoBehaviour
{
    private ShopModel _shopModel;
    private DescriptionManager _descriptionManager;
    private CurrencyManager _currencyManager;

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager)
    {
        _descriptionManager = descriptionManager;
        _currencyManager = currencyManager;
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

    public void OnPointerEnter(ShopItem shopItem)
    {
        ShopModel model = shopItem.GetShopModel();

        _descriptionManager?.ItemDescription
        (
            model.CheckItemType(),
            model.ItemDataSO.buyingPrice,
            model.ItemDataSO.sellingPrice,
            model.ItemDataSO.weight,
            model.CheckItemRarity()
        );
    }

    public void OnPointerDown(ShopItem shopItem)
    {
        var model = shopItem.GetShopModel();

        if(CheckItemPrice(model) && CheckItemQuantity(model))
        {
            _currencyManager.ItemPurchased(model.ItemDataSO.buyingPrice);
            model.DecreaseItemQuantity();
            shopItem.DisplayItemQuantity();
        }
    }

    private bool CheckItemPrice(ShopModel model)
    {
        return model.ItemDataSO.buyingPrice <= _currencyManager.GetCurrentCurrency();
    }

    private bool CheckItemQuantity(ShopModel model)
    {
        return model.GetItemQuantity() > 0;
    }

    public ShopModel GetShopModel()
    {
        return _shopModel;
    }
}
