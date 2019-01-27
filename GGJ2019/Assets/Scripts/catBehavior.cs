using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class catBehavior : MonoBehaviour {
    
    [SerializeField]
    private int range = 3;

    Vector3 highestPriority = new Vector3();
    int highestP = 0;

    void Awake(){
    }

    // Update is called once per frame
    void Update(){
        move();
    }

    Vector3 getPriority(){
        Vector3Int catPos = gameObject.GetComponentInParent<GridLayout>().WorldToCell(gameObject.transform.position);
        gridItem[] arrItem = FindObjectsOfType<gridItem>();
        float[] itemDis = new float[arrItem.Length];
        
        for (int i = 0; i < arrItem.Length; ++i){
            Vector3 itemWorld = arrItem[i].gameObject.transform.position;
            Vector3Int itemCell = gameObject.GetComponentInParent<GridLayout>().WorldToCell(itemWorld);
            itemDis[i] = Vector3.Distance(catPos, itemCell);
            
            if (arrItem[i].priority > highestP)
            {
                highestP = arrItem[i].priority;
                highestPriority = arrItem[i].gameObject.transform.position;
            }
        }
        return highestPriority;
    }

    void move(){
        Vector3 destination = getPriority();
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, .01f);
        highestP = 0;
    }
}
