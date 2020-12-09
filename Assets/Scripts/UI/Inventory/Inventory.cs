using System.Collections.Generic;

[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[28];
    public void Clear()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].RemoveItem();
        }
    }
}


