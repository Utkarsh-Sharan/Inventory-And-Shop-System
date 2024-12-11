using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    private Dictionary<(ItemType, ItemRarity), ShopItem> _allShopItems;

    public void Init(ShopController shopController)
    {
        _allShopItems = shopController.GetShopItems();
    }

    public void ShowAllItems()
    {
        FilterItemsByTab(ShopTab.ALL_ITEMS);
    }

    public void ShowArmorItems()
    {
        FilterItemsByTab(ShopTab.ARMOR_ITEMS);
    }

    public void ShowHelmetItems()
    {
        FilterItemsByTab(ShopTab.HELMET_ITEMS);
    }

    public void ShowHealableItems()
    {
        FilterItemsByTab(ShopTab.HEALABLE_ITEMS);
    }

    public void ShowWeaponItems()
    {
        FilterItemsByTab(ShopTab.WEAPON_ITEMS);
    }

    public void ShowRingItems()
    {
        FilterItemsByTab(ShopTab.RING_ITEMS);
    }

    public void FilterItemsByTab(ShopTab selectedTab)
    {
        foreach (var kvp in _allShopItems)
        {
            var itemType = kvp.Key.Item1; //extract ItemType from key
            var shopItem = kvp.Value;

            //determine if the item should be displayed based on the selected tab
            bool shouldDisplay = selectedTab switch
            {
                ShopTab.ALL_ITEMS => true,
                ShopTab.ARMOR_ITEMS => itemType == ItemType.ARMOR,
                ShopTab.HELMET_ITEMS => itemType == ItemType.HELMET,
                ShopTab.HEALABLE_ITEMS => itemType == ItemType.HEALABLE,
                ShopTab.WEAPON_ITEMS => itemType == ItemType.WEAPON,
                ShopTab.RING_ITEMS => itemType == ItemType.RING,
                _ => false,
            };

            shopItem.gameObject.SetActive(shouldDisplay);
        }
    }
}
