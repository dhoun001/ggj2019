using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TileMapType
{
    Ground = 0,
    Blocker
}


public class Ground : MonoBehaviour
{
    public TileMapType mapType;
    public GameObject colliderObject;

    // Start is called before the first frame update
    void Start()
    {

        if (mapType == TileMapType.Ground)
        {
            GameManager.Instance.currentGroundTileMap = this.GetComponent<Tilemap>();
        }
        else if (mapType == TileMapType.Blocker)
        {
            GameManager.Instance.currentBlockerTileMap = this.GetComponent<Tilemap>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Item")
        {
            colliderObject = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Item")
        {
            colliderObject = null;
        }
    }

    public bool DestroyItems()
    {
        Debug.Log("Destroying!");
        if (colliderObject != null)
        {
            Debug.Log("Found something to destroy!");
            Destroy(colliderObject);
            colliderObject = null;
            return true;
        }
        return false;
    }
}
