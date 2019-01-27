using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [System.Serializable]
    public class InventoryItem
    {
        public ItemType type;
        public int quantity;
    }

    public InventoryBar display;
    public List<InventoryItem> itemList;
    private List<Item> items;
    private int maxSlots;
    // Start is called before the first frame update
    void Start()
    {
        items = new List<Item>();
        maxSlots = itemList.Count;
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initialize()
    {
        display.Initalize(itemList.Count);
        PopulateItems();
    }

    public void FlushItems()
    {
        foreach (Item item in items)
        {
            display.Remove(item.itemType);
        }
        items.Clear();
    }

    public void PopulateItems()
    {
        foreach (InventoryItem item in itemList)
        {
            Item newItem = new Item(item.type, item.quantity);
            AddItem(newItem);
        }
    }

    /// <summary>
    /// Adds a new item in the internal inventory
    /// Displays it if it isn't on the hotbar, otherwise increases the quantity of the item
    /// Ideally used for dragging items back to your inventory
    /// </summary>
    /// <param name="type"></param>
    public void AddItem(ItemType type)
    {
        foreach (Item currentItem in items)
        {
            if (currentItem.itemType == type)
            {
                currentItem.quantity += 1;
                display.UpdateAmount(currentItem);
                return;
            }
        }
        //Do not add new item if we don't have room.
        if (inventoryFull())
        {
            Debug.LogWarning("Inventory Full!");
            return;
        }
        //There's no item in the hotbar, so let's create it!
        Item item = new Item(type, 1);
        items.Add(item);
        display.Place(item);
    }

    /// <summary>
    ///Adds a new item in the internal inventory and displays it
    ///if it doesn't exist yet.
    ///Should only be used when initializing the inventory in the beginning.
    /// </summary>
    /// <param name="item"></param>
    public void AddItem(Item item)
    {
        if(item.quantity <= 0)
        {
            Debug.LogWarning("Item quantity should be more than 0!");
        }
        items.Add(item);
        display.Place(item);
    }

    /// <summary>
    /// Removes the item in the internal inventory.
    /// If there are no items left, remove it from the display
    /// and the internal inventory.
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(ItemType item)
    {
        foreach (Item currentItem in items)
        {
            if (currentItem.itemType == item)
            {
                currentItem.quantity -= 1;
                if(currentItem.quantity <= 0)
                {
                    items.Remove(currentItem);
                    display.Remove(item);
                }
                else
                {
                    display.UpdateAmount(currentItem);
                }
                return;
            }
        }
    }

    public bool inventoryFull()
    {
        return items.Count == maxSlots;
    }
}
