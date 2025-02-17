using UnityEngine.EventSystems;

public class ShopItem : TradeItem<ShopModel, ShopController>
{ 
    public override void OnPointerEnter(PointerEventData eventData)
    {
        controller.DescribeItem(this);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        controller.PurchaseItem(this);
    }
}
