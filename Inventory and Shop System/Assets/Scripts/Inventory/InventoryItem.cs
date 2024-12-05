using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private Image _rarityBackgroundImage;
    [SerializeField] private TextMeshProUGUI _itemQuantityText;

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
        _itemImage.sprite = _inventoryModel.ItemDataSO.itemImage;
        _rarityBackgroundImage.sprite = _inventoryModel.ItemDataSO.rarityBackgroundImage;
        UpdateItemQuantity();
    }

    public void UpdateItemQuantity()
    {
        _itemQuantityText.text = _inventoryModel.GetItemQuantity().ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _inventoryController.DescribeItem(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _inventoryController.RemoveItemFromInventory(this);
    }

    public InventoryModel GetInventoryModel()
    {
        return _inventoryModel;
    }
}
