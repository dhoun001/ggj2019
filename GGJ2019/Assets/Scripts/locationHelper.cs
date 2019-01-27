using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationHelper
{
    private float[] distance = new float[100];
    private Vector3[] worldPos;
    private Vector3Int[] cellPos;
    private Vector3Int catPos;
    private int[] arrItemPriority;
    public int indexOfTarget = 0;

    public locationHelper() { }
    public locationHelper(Vector3[] world, Vector3Int[] cell, Vector3Int cat, int[] arr) {worldPos = world; cellPos = cell; catPos = cat; arrItemPriority = arr; }

    public Vector3 findTarget(){
        float lowestDistance = 100;
        int[] indexHighDis = new int[cellPos.Length];
        int tracker = 0;
        int highestPriority = 0;
        indexOfTarget = 0;

        //find all distances between objects and the caat
        for (int i = 0; i < cellPos.Length; ++i){
            distance[i] = Vector3.Distance(catPos, cellPos[i]);
        }

        //checks for ties in closest
        for (int i = 0; i < cellPos.Length; ++i){
            if (catPos == cellPos[i]){
                ++i;
            }
            else if (distance[i] < lowestDistance){
                lowestDistance = distance[i];
                indexHighDis[tracker] = i;
                indexOfTarget = i;
            }
            else if (distance[i] == lowestDistance){
                lowestDistance = distance[i];
                tracker++;
                indexHighDis[tracker] = i;
            }
        }

        //tiebreaker handler, checks for priority
        if (tracker > 0){
            for (int i = 0; i < indexHighDis.Length; ++i){
                if (arrItemPriority[indexHighDis[i]] > highestPriority){
                    highestPriority = arrItemPriority[indexHighDis[i]];
                    indexOfTarget = indexHighDis[i];
                }
            }
            return worldPos[indexOfTarget];
        }
        else{
            return worldPos[indexOfTarget];
        }
    }
}
