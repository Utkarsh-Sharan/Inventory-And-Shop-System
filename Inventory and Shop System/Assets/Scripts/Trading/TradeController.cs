using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeController<TModel, TItem> : MonoBehaviour 
    where TModel : class 
    where TItem : TradeItem<TModel, TradeController<TModel, TItem>>
{
    protected Dictionary<(ItemType, ItemRarity), TModel> model = new();
    protected Dictionary<(ItemType, ItemRarity), TItem> itemQuantityUI = new();

    protected DescriptionManager descriptionManager;
    protected CurrencyManager currencyManager;
    protected WeightManager weightManager;
    protected AudioManager audioManager;

    public void Init(DescriptionManager descriptionManager, CurrencyManager currencyManager, WeightManager weightManager, AudioManager audioManager)
    {
        this.descriptionManager = descriptionManager;
        this.currencyManager = currencyManager;
        this.weightManager = weightManager;
        this.audioManager = audioManager;
    }

    protected void PlaySound()
    {
        audioManager.PlaySound(AudioType.ITEM_CLICKED);
    }

    protected void UpdateCurrencyAndWeight(TradeModel model)
    {
        if(model is ShopModel shopModel)
        {
            currencyManager.ItemPurchased(shopModel.ItemDataSO.buyingPrice);
            weightManager.ItemPurchased(shopModel.ItemDataSO.weight);
        }
        else if(model is InventoryModel inventoryModel)
        {
            currencyManager.ItemSold(inventoryModel.ItemDataSO.sellingPrice);
            weightManager.ItemSold(inventoryModel.ItemDataSO.weight);
        }
    }
}
