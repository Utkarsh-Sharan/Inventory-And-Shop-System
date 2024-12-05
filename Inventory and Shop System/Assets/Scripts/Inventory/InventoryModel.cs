public class InventoryModel
{
    public ItemDataScriptableObject ItemDataSO { get; private set; }
    private int _quantity;

    public InventoryModel(ItemDataScriptableObject itemDataSO)
    {
        ItemDataSO = itemDataSO;
        _quantity = 1;
    }

    public int IncreaseItemQuantity()
    {
        return ++_quantity;
    }

    public int DecreaseItemQuantity()
    {
        return --_quantity;
    }

    public int GetItemQuantity()
    {
        return _quantity;
    }
}
