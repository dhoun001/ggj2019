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
                Destroy(draggingObject);
                Inventory.Instance.AddItem(draggingObject.GetComponent<DraggableItem>().itemType);
            }
            else
            {
                Debug.Log("You missed the inventory bar!");
            }
            UpdateDraggedObjectPosition();
            //Drop the dragged object onto a cell.
            //TileBase tile = GameManager.Instance.currentTileMap.GetTile(GameManager.Instance.currentTileMap.WorldToCell(draggingObject.transform.position));
            Vector3Int cellPos = GameManager.Instance.currentBlockerTileMap.WorldToCell(draggingObject.transform.position);
            Debug.Log("Target cell position: " + cellPos);

            //draggingObject.transform.position = GameManager.Instance.currentGroundTileMap.CellToWorld(cellPos);
            Debug.Log("Final position: " + draggingObject.transform.position);

            if (!GameManager.Instance.currentBlockerTileMap.HasTile(cellPos))
                //&& GameManager.Instance.currentGroundTileMap.GetComponent<TilemapCollider2D>().bounds.Contains(draggingObject.transform.position))
            {
                gridItem[] interactableObjects = FindObjectsOfType<gridItem>();
                foreach (gridItem item in interactableObjects)
                {
                    Vector3Int itemCellPos = GameManager.Instance.currentBlockerTileMap.WorldToCell(item.transform.position);
                    if(itemCellPos == cellPos)
                    {
                        Debug.LogError("Item blocked by an interactable object.");
                        return;
                    }
                }
            }
            else
            {
                Debug.Log("Tile is on blocker.");
            }

            //Right now the only way that the item gets destroyed is if its in the trigger of the blockers
            GameManager.Instance.currentBlockerTileMap.GetComponent<Ground>().DestroyItems();
            draggingObject = null;
            canDrag = isSlotted ? true : false;
            Debug.Log("Done dragging.");
        }

    }

    public void UpdateDraggedObjectPosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Since Input.mousePosition is only taking a 2D coordinate, we need to specify our z coordinate to be in front of the camera
        pos.z = 0;
        draggingObject.transform.position = pos;
    }
}
