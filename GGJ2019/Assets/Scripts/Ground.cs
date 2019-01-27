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
    GameObject colliderObject;
    private void Awake()
    {
    }
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
            Debug.Log("Looking at " + collision.name);
            colliderObject = collision.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name + " is exiting the trigger!");
        if (collision.tag == "Item")
        {
            colliderObject = null;
        }
    }

    public void DestroyItems()
    {
        Debug.Log("Destroying!");
        if (colliderObject != null)
        {
            Debug.Log("Found something to destroy!");
            Destroy(colliderObject);
            colliderObject = null;
        }
    }
}
