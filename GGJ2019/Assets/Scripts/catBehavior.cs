using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class catBehavior : MonoBehaviour {
    
    [SerializeField]
    private int range = 3;

    Vector3 highestPriority = new Vector3();
    gridItem[] arrItem;
    //int index = 0;
    private bool interpolating = false;

    void Awake(){
        arrItem = FindObjectsOfType<gridItem>();
    }

    // Update is called once per frame
    void Update(){
        StartCoroutine("moving");
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
        //highestPriority = calculation.findTarget();
        //index = calculation.indexOfTarget;
        return calculation.findTarget();
    }

    IEnumerator moving()
    {
        Vector3 destination = getPriority();
        Vector3 position = gameObject.transform.position;
        gameObject.transform.position = Vector3.Lerp(position, destination, .01f);
        yield return null;
    }
}
