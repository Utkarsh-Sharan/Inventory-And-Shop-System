using UnityEngine.EventSystems;

public class InventoryItem : TradeItem
{
    private InventoryModel _inventoryModel;
    private InventoryController _inventoryController;

    public void Initialize(InventoryModel inventoryModel, InventoryController inventoryController)
    {
        _inventoryModel = inventoryModel;
        _inventoryController = inventoryController;
        UpdateItemImageRarityAndQuantity();
    }

    private void UpdateItemImageRarityAndQuantity()
    {
        itemImage.sprite = _inventoryModel.ItemDataSO.itemImage;
        rarityBackgroundImage.sprite = _inventoryModel.ItemDataSO.rarityBackgroundImage;
        UpdateItemQuantity();
    }

    public void UpdateItemQuantity()
    {
        itemQuantity.text = _inventoryModel.GetItemQuantity().ToString();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _inventoryController.DescribeItem(this);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        _inventoryController.SellItem(this);
    }

    public InventoryModel GetInventoryModel()
    {
        return _inventoryModel;
    }
}
