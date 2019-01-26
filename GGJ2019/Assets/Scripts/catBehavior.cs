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
        Vector3 catPos = gameObject.GetComponentInParent<GridLayout>().WorldToCell(gameObject.transform.position);
        gridItem[] arrItem = FindObjectsOfType<gridItem>();
        for(int i = 0; i < arrItem.Length; ++i){
            Vector3 itemWorld = arrItem[i].gameObject.transform.position;
            Debug.Log(itemWorld);
            /*
            if (Mathf.Abs(itemWorld.x) - range <= Mathf.Abs(catPos.x)){
                Debug.Log("Hello");
                if (Mathf.Abs(itemWorld.y) - range <= Mathf.Abs(catPos.y)){//TODO: must fix later, testing functionality first. breaks when itemworld is negative and cat pos is positive and vice versa.
                    Debug.Log("Hello");
                    highestP = arrItem[i].priority;
                    highestPriority = arrItem[i].GetComponentInParent<Tilemap>().WorldToCell(arrItem[i].gameObject.transform.position);
                    Debug.Log(highestPriority);
                }
            }
            */
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
        Debug.Log(destination);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, destination, .01f);
        highestP = 0;
    }
}
