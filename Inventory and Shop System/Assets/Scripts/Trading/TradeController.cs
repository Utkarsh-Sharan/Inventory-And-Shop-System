using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeController : MonoBehaviour
{
    protected const bool IS_BUYING = true;

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

    protected void UpdateCurrencyAndWeight(TradeModel model, bool isBuying)
    {
        if(isBuying)
        {
            currencyManager.ItemPurchased(model.ItemDataSO.buyingPrice);
            weightManager.ItemPurchased(model.ItemDataSO.weight);
        }
        else if(!isBuying)
        {
            currencyManager.ItemSold(model.ItemDataSO.sellingPrice);
            weightManager.ItemSold(model.ItemDataSO.weight);
        }
    }
}
