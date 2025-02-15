using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeController : MonoBehaviour
{
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

    public void DescribeItem<TModel, TController>(TradeItem<TModel, TController> tradeItem)
        where TModel : TradeModel
        where TController : TradeController
    {
        audioManager.PlaySound(AudioType.ITEM_HOVER);

        TradeModel model = tradeItem.GetModel();

        descriptionManager.ItemDescription
        (
            model.GetItemType(),
            model.ItemDataSO.buyingPrice,
            model.ItemDataSO.sellingPrice,
            model.ItemDataSO.weight,
            model.GetItemRarity()
        );
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
