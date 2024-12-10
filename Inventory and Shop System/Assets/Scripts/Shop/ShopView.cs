using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    private ShopController _shopController;

    private Dictionary<(ItemType, ItemRarity), ShopItem> _allShopItems;

    public void Init(ShopController shopController)
    {
        _shopController = shopController;
        _allShopItems = shopController.GetShopItems();
    }

    public void ShowAllItems()
    {
        FilterItemsByTab(ItemType.ALL);
    }

    public void ShowArmorItems()
    {
        FilterItemsByTab(ItemType.ARMOR);
    }

    public void ShowHelmetItems()
    {
        FilterItemsByTab(ItemType.HELMET);
    }

    public void ShowHealableItems()
    {
        FilterItemsByTab(ItemType.HEALABLE);
    }

    public void ShowWeaponItems()
    {
        FilterItemsByTab(ItemType.WEAPON);
    }

    public void ShowRingItems()
    {
        FilterItemsByTab(ItemType.RING);
    }

    public void FilterItemsByTab(ItemType selectedTab)
    {
        foreach (var kvp in _allShopItems)
        {
            var itemType = kvp.Key.Item1; //extract ItemType from key
            var shopItem = kvp.Value;

            //determine if the item should be displayed based on the selected tab
            bool shouldDisplay = selectedTab switch
            {
                ItemType.ALL => true,               //show all items
                _ => itemType == selectedTab,       //show items matching the selected tab
            };

            shopItem.gameObject.SetActive(shouldDisplay);
        }
    }
}
