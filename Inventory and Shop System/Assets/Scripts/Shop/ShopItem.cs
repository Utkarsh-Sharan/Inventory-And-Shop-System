using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private ItemDataScriptableObject _itemDataSO;
    [SerializeField] private DescriptionManager _descriptionManager;

    private void Start()
    {
        
    }

    public void ItemDescription()
    {
        _descriptionManager.ItemDescription
            (
            CheckItemType(), 
            this._itemDataSO.buyingPrice, 
            this._itemDataSO.sellingPrice, 
            this._itemDataSO.weight, 
            CheckItemRarity(), 
            this._itemDataSO.quantity
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

    private string CheckItemRarity()
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
}
