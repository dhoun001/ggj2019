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
    public void OnBeginDrag(PointerEventData eventData)
    {
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
        if(Inventory.Instance.display.IsItemInsideBar(draggingObject.transform.position))
        {
            Inventory.Instance.AddItem(itemType);
            Destroy(draggingObject);
        }
        else
        {
            Debug.Log("You missed the inventory bar!");
        }
        draggingObject = null;
    }

}
