public class ShopModel : TradeModel
{
    public ShopModel(ItemDataScriptableObject itemDataSO) : base(itemDataSO)
    {
        quantity = itemDataSO.itemInitialQuantity;
    }
}
