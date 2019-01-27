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

    public string petName = "Pet Name";

    public void StartRun()
    {
        //TODO: disable inventory
        //TODO: start cat movement
    }

    public void RestartRun()
    {
        //TODO: return all inventory items to hotbar
        //TODO: reenable inventory
        //TODO: Reset cat to starting position
        //TODO: reset all other prop data
    }
}
