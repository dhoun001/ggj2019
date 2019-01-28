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
            GameManager.Instance.currentBlockerTileMap = this.GetComponent<Tilemap>();
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
}
