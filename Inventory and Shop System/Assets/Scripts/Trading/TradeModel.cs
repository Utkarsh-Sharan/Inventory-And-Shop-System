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
