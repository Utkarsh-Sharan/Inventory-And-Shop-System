public class ShopModel
{
    public ItemDataScriptableObject ItemDataSO { get; private set; }
    private int _quantity;

    public ShopModel(ItemDataScriptableObject itemDataSO)
    {
        ItemDataSO = itemDataSO;
        SetInitialQuantity();
    }

    private void SetInitialQuantity()
    {
        switch (this.ItemDataSO.itemRarity)
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

    public void DecreaseItemQuantity()
    {
        if(_quantity > 0)
            --_quantity;
    }

    public int GetItemQuantity()
    {
        return _quantity;
    }
}
