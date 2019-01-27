using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public bool isSlotted = false;
    public bool canDrag = true;
    public GameObject sourceObject;
    private GameObject draggingObject;
    public Item sourceItem;
    public Text amountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void UpdateQuantity(int amount)
    {
        amountText.text = amount.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isSlotted)
        {
            //Create a clone to replace the spot of the former item.
            GameObject clone = Instantiate(sourceObject, sourceObject.transform.parent);
            //The source object is now being dragged out of the hotbar, so we will declare it as such
            draggingObject = sourceObject;
            //The clone is now the new source object.
            sourceObject = clone;
            //Enable dragging for this object.
            draggingObject.GetComponent<DraggableItem>().enabled = true;
            //Remove the item, perhaps even from the hotbar if it was the last one.
            Inventory.Instance.RemoveItem(sourceItem.itemType);
            Debug.Log("Begin dragging.");
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(canDrag)
        {
            UpdateDraggedObjectPosition();
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            if (Inventory.Instance.display.IsItemInsideBar(draggingObject.transform.position))
            {
                ReturnItemToInventory();
                return;
            }
            else
            {
                Debug.LogWarning("You missed the inventory bar!");
            }
            //Drop the dragged object onto a cell.
            Vector3Int cellPos = GameManager.Instance.currentBlockerTileMap.WorldToCell(draggingObject.transform.position);
            //Debug.Log("Target cell position: " + cellPos);

            //LOOK HERE FOR MAIN DESTROYING FUNCTION. EVERYTHING IN THE FUNCTION ABOOVE IS REDUDANT FOR NOW
            //Right now the only way that the item gets destroyed is if its in the trigger of the blockers
            if (!draggingObject.GetComponent<DraggableItem>().CanPlace())
            {
                ReturnItemToInventory();
                return;
            }

            gridItem[] interactableObjects = FindObjectsOfType<gridItem>();
            foreach (gridItem item in interactableObjects)
            {
                Vector3Int itemCellPos = GameManager.Instance.currentBlockerTileMap.WorldToCell(item.transform.position);
                if (itemCellPos == cellPos && item.name != draggingObject.name)
                {
                    Debug.LogWarning("Item blocked by an interactable object.");
                    ReturnItemToInventory();
                }
            }
            FinishPlacement();
        }

    }

    public void FinishPlacement()
    {
        GameManager.Instance.placedObjects.Add(draggingObject);
        draggingObject.GetComponent<DraggableItem>().ToggleHitBox();
        draggingObject = null;
        canDrag = isSlotted ? true : false;
        Debug.Log("Object placed!");
    }

    public void UpdateDraggedObjectPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Since Input.mousePosition is only taking a 2D coordinate, we need to specify our z coordinate to be in front of the camera
        pos.z = 0;
        draggingObject.transform.position = pos;
    }

    /// <summary>
    /// Returns the dragging item back to the inventory.
    /// Happens if the item is dragged back into the inventory or is in an illegal spot.
    /// </summary>
    public void ReturnItemToInventory()
    {
        GameManager.Instance.placedObjects.Remove(draggingObject);
        Destroy(draggingObject);
        Inventory.Instance.AddItem(draggingObject.GetComponent<DraggableItem>().itemType);
    }
}
