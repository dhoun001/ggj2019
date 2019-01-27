using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public ItemType itemType;
    public bool isDraggable = true;
    public GameObject draggingObject;
    private Vector3 startPosition;
    private Transform startParent;
    private int Z_LAYER = 0;
    public BoxCollider2D placingBox;
    public BoxCollider2D draggingBox;

    void Start()
    {
        placingBox.enabled = true;
        draggingBox.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ToggleHitBox();
        draggingObject = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Since Input.mousePosition is only taking a 2D coordinate, we need to specify our z coordinate to be in front of the camera
        pos.z = Z_LAYER;
        transform.position = pos;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Inventory.Instance.display.IsItemInsideBar(draggingObject.transform.position))
        {
            Inventory.Instance.AddItem(itemType);
            Destroy(draggingObject);
        }
        else
        {
            Debug.Log("You missed the inventory bar!");
        }
        if (GameManager.Instance.currentGroundTileMap.GetComponent<Ground>().DestroyItems())
        {
            ReturnItemToInventory();
        }
        ToggleHitBox();
    }

    public void ToggleHitBox()
    {
        if(placingBox.enabled)
        {
            placingBox.enabled = false;
            draggingBox.enabled = true;
        }
        else
        {
            placingBox.enabled = true;
            draggingBox.enabled = false;
        }
    }

    /// <summary>
    /// Returns the dragging item back to the inventory.
    /// Happens if the item is dragged back into the inventory or is in an illegal spot.
    /// </summary>
    public void ReturnItemToInventory()
    {
        Destroy(draggingObject);
        Inventory.Instance.AddItem(draggingObject.GetComponent<DraggableItem>().itemType);
        draggingObject = null;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tag of trigger: " + collision.tag);
        
    }

}
