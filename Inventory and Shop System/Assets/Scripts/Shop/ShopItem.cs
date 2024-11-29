using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ItemDataScriptableObject _itemDataSO;
    [SerializeField] private DescriptionManager _descriptionManager;

    private int _quantity;

    private void Start()
    {
        switch (this._itemDataSO.itemRarity)
        {
            case ItemRarity.COMMON:
                _quantity = 3;
                break;

            case ItemRarity.RARE:
                _quantity = 2;
                break;

            case ItemRarity.EPIC:
                _quantity = 2;
                break;

            case ItemRarity.LEGENDARY:
                _quantity = 1;
                break;
        }
    }

    public void ItemDescription()
    {
        _descriptionManager.ItemDescription
            (
            CheckItemType(), 
            this._itemDataSO.buyingPrice, 
            this._itemDataSO.sellingPrice, 
            this._itemDataSO.weight, 
            CheckItemRarityAndSetQuantity(), 
            _quantity
            );
    }

    private string CheckItemType()
    {
        switch (this._itemDataSO.itemType) 
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

    private string CheckItemRarityAndSetQuantity()
    {
        switch (this._itemDataSO.itemRarity)
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

    public void OnButtonPress()
    {
        if (this._quantity == 0)
            return;

        --this._quantity;
    }

    public void OnButtonRelease()
    {
        ItemDescription();
    }
}
