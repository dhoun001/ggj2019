using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class catBehavior : MonoBehaviour {
    
    [SerializeField]
    private int range = 3;

    Vector3 highestPriority = new Vector3();
    gridItem[] arrItem;
    int index = 0;
    void Awake(){
        arrItem = FindObjectsOfType<gridItem>();
    }

    // Update is called once per frame
    void Update(){
        move();
    }

    Vector3 getPriority(){
        Vector3Int catPos = gameObject.GetComponentInParent<GridLayout>().WorldToCell(gameObject.transform.position);
        int[] arrItemPrio = new int[arrItem.Length];
        Vector3[] worldList = new Vector3[arrItem.Length];
        Vector3Int[] cellList = new Vector3Int[arrItem.Length];
        for (int i = 0; i < arrItem.Length; ++i){
            worldList[i] = arrItem[i].gameObject.transform.position;
            cellList[i] = gameObject.GetComponentInParent<GridLayout>().WorldToCell(worldList[i]);
            arrItemPrio[i] = arrItem[i].priority;
        }
        locationHelper calculation = new locationHelper(worldList, cellList, catPos, arrItemPrio);
        highestPriority = calculation.findTarget();
        index = calculation.indexOfTarget;
        return highestPriority;
    }

    void move(){
        Vector3 destination = getPriority();
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, .01f);
        //gridItem[] newArr = new gridItem[arrItem.Length - 1];
        //for(int i = 0; i < arrItem.Length; ++i){
        //    if (i == index){
        //        i++;
        //    }
        //    else{
        //        newArr[i] = arrItem[i];
        //    }
        //}
        //arrItem = newArr;
        //Debug.Log(arrItem);
    }
}
