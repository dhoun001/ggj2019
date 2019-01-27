using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class gridItem : MonoBehaviour {

    [SerializeField]
    public int priority = 0;
    public float additionalSpeed = 0f;
    public bool isWall = false;
    public bool isElevated = false;

    public virtual void OnSeenByCat()
    {

    }

    public virtual void OnArrive()
    {

    }

    void Awake () {

    }

	// Update is called once per frame
	void Update () {
	    
	}
}
