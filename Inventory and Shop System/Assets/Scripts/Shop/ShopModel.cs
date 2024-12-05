using UnityEngine;

public class ShopModel
{
    public ItemDataScriptableObject ItemDataSO { get; private set; }
    private int _quantity;

    public ShopModel(ItemDataScriptableObject itemDataSO)
    {
        ItemDataSO = itemDataSO;
        _quantity = ItemDataSO.itemInitialQuantity;
    }

    public void DecreaseItemQuantity()
    {
        --_quantity;
    }

    public void IncreaseItemQuantity()
    {
        ++_quantity;
    }

    public int GetItemQuantity()
    {
        return _quantity;
    }

    public string GetItemType()
    {
        switch (ItemDataSO.itemType)
        {
            case ItemType.ARMOR:
                return StringConstants.armorString;

            case ItemType.HELMET:
                return StringConstants.helmetString;

            case ItemType.WEAPON:
                return StringConstants.weaponString;

            case ItemType.HEALABLE:
                return StringConstants.healableString;

            case ItemType.RING:
                return StringConstants.ringString;

            default:
                Debug.LogError("Item type does not exist!");
                break;
        }
        return null;
    }

    public string GetItemRarity()
    {
        switch (ItemDataSO.itemRarity)
        {
            case ItemRarity.COMMON:
                return StringConstants.commonRarityString;

            case ItemRarity.RARE:
                return StringConstants.rareRarityString;

            case ItemRarity.EPIC:
                return StringConstants.epicRarityString;

            case ItemRarity.LEGENDARY:
                return StringConstants.legendaryRarityString;

            default:
                Debug.LogError("Rarity does not exist!");
                break;
        }
        return null;
    }
}
