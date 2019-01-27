using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using DG.Tweening;

public class catBehavior : MonoBehaviour {
    

    void Awake(){
    }

    // Update is called once per frame
    void Update(){
    }

    private void moving()
    {
        //Check to see if valid space, if so:
        if (true)
        {
            Vector3 destination = new Vector3();
        }
    }

    private void getClosestObject(){
        List<gridItem> objects = new List<gridItem>();
        float lowestDistance = 0;
        while(FindObjectOfType<GameObject>() != null)
        {
            objects.Add(FindObjectOfType<gridItem>());
        }
        foreach (gridItem i in objects)
        {
            if (objects[i] )
        }
    }
}
