using System.Collections.Generic;

public class ItemGenerationManager
{
    private InventoryManager _inventoryManager;
    private List<ItemDataScriptableObject> _shopItems;
    private RandomItemGenerator _randomItemGenerator;

    public ItemGenerationManager(List<ItemDataScriptableObject> shopItems, RandomItemGenerator randomItemGenerator)
    {
        _shopItems = shopItems;
        _randomItemGenerator = randomItemGenerator;
    }

    public void Init(InventoryManager inventoryManager)
    {
        _inventoryManager = inventoryManager;
        _randomItemGenerator.Initialize(_inventoryManager, _shopItems);
    }
}
