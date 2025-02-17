using UnityEngine.EventSystems;

public class InventoryItem : TradeItem<InventoryModel, InventoryController>
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        controller.DescribeItem(this);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        controller.SellItem(this);
    }
}
