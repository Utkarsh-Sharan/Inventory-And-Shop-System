using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPopulator : MonoBehaviour
{
    public void PopulateShop(Transform shopPanel, GameObject shopItemPrefab, List<ItemDataScriptableObject> shopItems, DescriptionManager descriptionManager)
    {
        foreach (var itemData in shopItems)
        {
            var shopItem = Instantiate(shopItemPrefab, shopPanel);
            ShopController controller = shopItem.GetComponent<ShopController>();
            controller.Initialize(itemData, descriptionManager);
        }
    }
}
