using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Vase = 0,
    Lure,
    Box
};

public class Item
{
    public ItemType itemType;
    public int quantity;

    public Item(ItemType type, int amount = 0)
    {
        itemType = type;
        quantity = amount;
    }
}
