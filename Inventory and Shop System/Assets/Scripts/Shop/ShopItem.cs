using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{ 
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _rarityBackgroundImage;
    [SerializeField] private TextMeshProUGUI _itemQuantity;

    private ShopModel _shopModel;
    private ShopController _shopController;

    public void SetShopController(ShopController shopController)
    {
        _shopController = shopController;
    }

    public void Initialize(ShopModel shopModel)
    {
        _shopModel = shopModel;
        DisplayItemImageRarityAndQuantity();
    }

    public void DisplayItemImageRarityAndQuantity()
    {
        _itemImage.sprite = _shopModel.ItemDataSO.itemImage;
        _rarityBackgroundImage.sprite = _shopModel.ItemDataSO.rarityBackgroundImage;
        DisplayItemQuantity();
    }

    public void DisplayItemQuantity()
    {
        _itemQuantity.text = _shopModel.GetItemQuantity().ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _shopController?.OnPointerEnter(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _shopController?.OnPointerDown(this);
    }

    public ShopModel GetShopModel()
    {
        return _shopModel;
    }
}
