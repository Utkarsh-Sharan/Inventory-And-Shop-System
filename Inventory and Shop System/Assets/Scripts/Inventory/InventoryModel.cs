public class InventoryModel : TradeModel
{   
    public InventoryModel(ItemDataScriptableObject itemDataSO) : base(itemDataSO)
    {
        quantity = 1;
    }
}
