using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataScriptableObject", menuName = "ScriptableObjects/ItemDataScriptableObject")]
public class ItemDataScriptableObject : ScriptableObject
{
    public Sprite itemImage;
    public Sprite rarityBackgroundImage;
    public ItemType itemType;
    public float buyingPrice;
    public float sellingPrice;
    public float weight;
    public ItemRarity itemRarity;
    public int itemInitialQuantity;
}
