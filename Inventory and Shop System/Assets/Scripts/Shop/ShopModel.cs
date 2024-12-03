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
        if(_quantity > 0)
            --_quantity;
    }

    public int GetItemQuantity()
    {
        return _quantity;
    }

    public string CheckItemType()
    {
        switch (ItemDataSO.itemType)
        {
            case ItemType.ARMOR:        //make constants for strings
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

    public string CheckItemRarity()
    {
        switch (ItemDataSO.itemRarity)
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
