using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TradeItem : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField] protected Image itemImage;
    [SerializeField] protected Image rarityBackgroundImage;
    [SerializeField] protected TextMeshProUGUI itemQuantity;

    public virtual void OnPointerEnter(PointerEventData eventData) { }

    public virtual void OnPointerDown(PointerEventData eventData) { }
}
