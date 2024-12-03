using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopController : MonoBehaviour
{
    private ShopModel _shopModel;
    private DescriptionManager _descriptionManager;

    public void Initialize(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems, DescriptionManager descriptionManager)
    {
        _descriptionManager = descriptionManager;
        
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
        model.DecreaseItemQuantity();
        shopItem.DisplayItemQuantity();
    }

    public ShopModel GetShopModel()
    {
        return _shopModel;
    }
}
