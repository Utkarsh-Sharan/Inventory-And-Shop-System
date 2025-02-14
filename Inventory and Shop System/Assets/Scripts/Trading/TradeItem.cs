using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TradeItem<TModel, TController> : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] protected Image itemImage;
    [SerializeField] protected Image rarityBackgroundImage;
    [SerializeField] protected TextMeshProUGUI itemQuantity;

    protected TModel model;
    protected TController controller;

    public void Initialize(TModel tradeModel, TController tradeController)
    {
        model = tradeModel;
        controller = tradeController;
        UpdateItemImageRarityAndQuantity();
    }

    private void UpdateItemImageRarityAndQuantity()
    {
        if(model is TradeModel tradeModel)
        {
            itemImage.sprite = tradeModel.ItemDataSO.itemImage;
            rarityBackgroundImage.sprite = tradeModel.ItemDataSO.rarityBackgroundImage;
            UpdateItemQuantity(tradeModel);
        }
    }

    public void UpdateItemQuantity(TradeModel tradeModel) => itemQuantity.text = tradeModel.GetItemQuantity().ToString();

    public virtual void OnPointerEnter(PointerEventData eventData) { }

    public virtual void OnPointerDown(PointerEventData eventData) { }

    public TModel GetModel() => model;
}
