using UnityEngine;

public class TradeModel
{
    public ItemDataScriptableObject ItemDataSO { get; private set; }
    protected int quantity;

    public TradeModel(ItemDataScriptableObject itemDataSO)
    {
        ItemDataSO = itemDataSO;
    }

    public void IncreaseItemQuantity() => ++quantity;

    public int DecreaseItemQuantity() => --quantity;

    public int GetItemQuantity() => quantity;

    public string GetItemType()
    {
        switch (ItemDataSO.itemType)
        {
            case ItemType.ARMOR:
                return StringConstants.ARMOR_STRING;

            case ItemType.HELMET:
                return StringConstants.HELMET_STRING;

            case ItemType.WEAPON:
                return StringConstants.WEAPON_STRING;

            case ItemType.HEALABLE:
                return StringConstants.HEALABLE_STRING;

            case ItemType.RING:
                return StringConstants.RING_STRING;

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
                return StringConstants.COMMON_RARITY_STRING;

            case ItemRarity.RARE:
                return StringConstants.RARE_RARITY_STRING;

            case ItemRarity.EPIC:
                return StringConstants.EPIC_RARITY_STRING;

            case ItemRarity.LEGENDARY:
                return StringConstants.LEGENDARY_RARITY_STRING;

            default:
                Debug.LogError("Rarity does not exist!");
                break;
        }
        return null;
    }
}
