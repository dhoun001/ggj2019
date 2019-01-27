using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class catBehavior : MonoBehaviour {
    
    //private Vector3 startingPos = gameObject.transform.position;
    [SerializeField] private float speed = 5f;

    void Awake(){
        //transform.Translate(startingPos);
    }

    // Update is called once per frame
    void Update(){
        moveCat();
    }

    private gridItem getClosestObject(){
        gridItem closest = new gridItem();
        List<gridItem> objects = new List<gridItem>();
        float lowestDistance = 100;
        var foundObj = FindObjectsOfType<gridItem>();
        for (int i = 0; i < foundObj.Length; i++)
        {
            objects.Add(foundObj[i]);
        }
        foreach (gridItem i in objects)
        {
            float distance = Vector3.Distance(i.transform.position, gameObject.transform.position);
            Debug.Log(distance);
            if (distance < lowestDistance)
            {
                lowestDistance = distance;
                closest = i;
            }
        }
        return closest;
    }

    private void moveCat(){
        gridItem closestObj = getClosestObject();
        Vector3 position = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, closestObj.transform.position, Time.deltaTime * speed);
    }
}
