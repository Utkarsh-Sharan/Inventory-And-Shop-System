using UnityEngine.EventSystems;

public class ShopItem : TradeItem
{ 
    private ShopModel _shopModel;
    private ShopController _shopController;

    public void Initialize(ShopModel shopModel, ShopController shopController)
    {
        _shopModel = shopModel;
        _shopController = shopController;
        DisplayItemImageRarityAndQuantity();
    }

    private void DisplayItemImageRarityAndQuantity()
    {
        itemImage.sprite = _shopModel.ItemDataSO.itemImage;
        rarityBackgroundImage.sprite = _shopModel.ItemDataSO.rarityBackgroundImage;
        DisplayItemQuantity();
    }

    public void DisplayItemQuantity()
    {
        itemQuantity.text = _shopModel.GetItemQuantity().ToString();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _shopController.DescribeItem(this);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        _shopController.PurchaseItem(this);
    }

    public ShopModel GetShopModel()
    {
        return _shopModel;
    }
}
