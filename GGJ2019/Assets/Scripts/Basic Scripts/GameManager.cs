using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : Singleton<GameManager>
{
    public int MaxLevel = 3;
    public int CurrentLevel = 0;
    public bool IsAtLastLevel { get { return CurrentLevel >= MaxLevel; } }
    public Tilemap currentGroundTileMap;
    public Tilemap currentBlockerTileMap;
    public List<GameObject> placedObjects;

    public string petName = "Pet Name";

    public void StartRun()
    {
        //TODO: disable inventory
        //TODO: start cat movement
    }

    public void RestartRun()
    {
        if(placedObjects.Count == 0 )
        {
            return;
        }
        foreach (GameObject obj in placedObjects)
        {
            Destroy(obj);
        }
        placedObjects.Clear();
        Inventory.Instance.FlushItems();
        Inventory.Instance.PopulateItems();
        //TODO: reenable inventory
        //TODO: Reset cat to starting position
    }
}
