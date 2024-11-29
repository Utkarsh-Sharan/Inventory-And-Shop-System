using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopController : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    private ShopModel _shopModel;
    private DescriptionManager _descriptionManager;
    [SerializeField] private ShopView _shopView;

    public void Initialize(ItemDataScriptableObject itemDataSO, DescriptionManager descriptionManager)
    {
        _shopModel = new ShopModel(itemDataSO);
        _shopView.SetShopController(this);
        _descriptionManager = descriptionManager;
        UpdateView();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        UpdateView();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _shopModel.DecreaseItemQuantity();
        UpdateView();
    }

    private void UpdateView()
    {
        _shopView.DisplayItemDescription(_descriptionManager);
    }

    public ShopModel GetShopModel()
    {
        return _shopModel;
    }
}
