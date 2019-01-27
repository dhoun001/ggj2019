using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationHelper : MonoBehaviour
{
    public float distance;
    public Vector3 worldPos;
    public Vector3Int cellPos;

    public locationHelper() { }
    public locationHelper(float dis, Vector3 world, Vector3Int cell) { distance = dis;  worldPos = world; cellPos = cell; }
}
