using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _rarityBackgroundImage;

    private ShopController _shopController;

    private void Start()
    {
        DisplayItemImageAndRarity();
    }

    private void DisplayItemImageAndRarity()
    {
        _itemImage.sprite = _shopController.GetShopModel().ItemDataSO.itemImage;
        _rarityBackgroundImage.sprite = _shopController.GetShopModel().ItemDataSO.rarityBackgroundImage;
    }

    public void SetShopController(ShopController shopController)
    {
        _shopController = shopController;
    }

    public void DisplayItemDescription(DescriptionManager descriptionManager)
    {
        descriptionManager.ItemDescription
            (
            CheckItemType(),
            _shopController.GetShopModel().ItemDataSO.buyingPrice,
            _shopController.GetShopModel().ItemDataSO.sellingPrice,
            _shopController.GetShopModel().ItemDataSO.weight,
            CheckItemRarity(),
            _shopController.GetShopModel().GetItemQuantity()
            );
    }

    private string CheckItemType()
    {
        switch (_shopController.GetShopModel().ItemDataSO.itemType)
        {
            case ItemType.ARMOR:
                return "Armor";

            case ItemType.HELMET:
                return "Helmet";

            case ItemType.WEAPON:
                return "Weapon";

            case ItemType.HEALABLE:
                return "Healable";

            case ItemType.RING:
                return "Ring";
        }
        return null;
    }

    private string CheckItemRarity()
    {
        switch (_shopController.GetShopModel().ItemDataSO.itemRarity)
        {
            case ItemRarity.COMMON:
                return "Common";

            case ItemRarity.RARE:
                return "Rare";

            case ItemRarity.EPIC:
                return "Epic";

            case ItemRarity.LEGENDARY:
                return "Legendary";
        }
        return null;
    }
}
