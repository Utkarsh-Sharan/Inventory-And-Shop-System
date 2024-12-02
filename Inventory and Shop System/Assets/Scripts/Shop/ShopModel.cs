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
}
