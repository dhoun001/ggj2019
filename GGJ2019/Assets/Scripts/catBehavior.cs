using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class catBehavior : MonoBehaviour {
    
    private Vector3 startingPos = new Vector3();

    void Awake(){
        startingPos = gameObject.transform.position;
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

    private gridItem getClosestObject(){
        gridItem closest = new gridItem();
        List<gridItem> objects = new List<gridItem>();
        float lowestDistance = 100;
        while(FindObjectOfType<gridItem>() != null){
            objects.Add(FindObjectOfType<gridItem>());
        }
        foreach (gridItem i in objects)
        {
            float distance = Vector3.Distance(i.transform.position, gameObject.transform.position);
            if (distance < lowestDistance)
            {
                lowestDistance = distance;
                closest = i;
            }
        }
        return closest;
    }

    private void moveCat(){
        
    }
}
