using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBar : ObjectPooler
{
    private List<ItemSlot> itemSlots;
    // Start is called before the first frame update

    private void Awake()
    {
        itemSlots = new List<ItemSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Initalize(int amount)
    {
        pooledAmount = amount;
        toggleOn = true;
        base.GenerateObjects();
        foreach (GameObject obj in pooledObjects)
        {
            itemSlots.Add(obj.GetComponent<ItemSlot>());
        }
    }

    /// <summary>
    /// Updates the item quantity visually.
    /// </summary>
    /// <param name="item"></param>
    public void UpdateAmount(Item item)
    {
        foreach(ItemSlot slot in itemSlots)
        {
            if(slot.isSlotted && slot.sourceItem.itemType == item.itemType)
            {
                slot.UpdateQuantity(item.quantity);
            }
        }
    }

    /// <summary>
    /// Places the item on the hotbar.
    /// </summary>
    /// <param name="item"></param>
    public void Place(Item item)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if(!slot.isSlotted)
            {
                //Instantiate the object in scene and place on hotbar
                GameObject obj = (GameObject)Instantiate(Resources.Load("Items/" + item.itemType.ToString()));
                obj.transform.position = slot.gameObject.transform.position;
                obj.transform.parent = slot.gameObject.transform;
                obj.GetComponent<DraggableItem>().enabled = false;
                //Pass in information for slot
                slot.sourceObject = obj;
                slot.sourceItem = item;
                slot.canDrag = true;
                slot.isSlotted = true;

                //Update quantity
                slot.amountText.enabled = true;
                slot.UpdateQuantity(item.quantity);
                return;
            }
        }
    }

    /// <summary>
    /// Removes the item from the hotbar.
    /// </summary>
    /// <param name="type"></param>
    public void Remove(ItemType type)
    {
        foreach (ItemSlot slot in itemSlots)
        {
            if(slot.isSlotted && slot.sourceItem.itemType == type)
            {
                Destroy(slot.sourceObject);
                slot.sourceObject = null;
                slot.sourceItem = null;
                slot.isSlotted = false;
                slot.amountText.enabled = false;
                return;
            }
        }
    }

    /// <summary>
    /// Used to check if a game object resides within the bounds of the inventory.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public bool IsItemInsideBar(Vector3 pos)
    {
        RectTransform rect = this.GetComponent<RectTransform>();
        if (RectTransformUtility.RectangleContainsScreenPoint(rect, Camera.main.WorldToScreenPoint(pos), Camera.main))
        {
            return true;
        }
        return false;
    }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

    public void Enable()
    {
        this.gameObject.SetActive(true);
    }
}
