using System.Collections.Generic;

public class ItemGenerationManager
{
    private List<ItemDataScriptableObject> _shopItems;
    private RandomItemGenerator _randomItemGenerator;

    public ItemGenerationManager(List<ItemDataScriptableObject> shopItems, RandomItemGenerator randomItemGenerator)
    {
        _shopItems = shopItems;
        _randomItemGenerator = randomItemGenerator;
    }

    public void Init(InventoryManager inventoryManager, AudioManager audioManager)
    {
        _randomItemGenerator.Initialize(inventoryManager, _shopItems, audioManager);
    }
}
