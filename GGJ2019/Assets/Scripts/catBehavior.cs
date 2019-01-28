using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class catBehavior : MonoBehaviour {
    
    //private Vector3 startingPos = gameObject.transform.position;
    public float speed = 5f;
    [SerializeField]
    public GameObject happyBub;
    [SerializeField]
    public GameObject angryBub;
    [SerializeField]
    public GameObject sleepBub;
    [SerializeField]
    public GameObject loveBub;

    private Animator _catAnimator;
    private Vector3 startCatPos;
    private SpriteRenderer _catRenderer;
    void Awake(){
        _catAnimator = GetComponent<Animator>();
        _catRenderer = GetComponent<SpriteRenderer>();
        startCatPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private gridItem getClosestObject()
    {
        gridItem closest = null;
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
            //Debug.Log(distance);
            if (distance < lowestDistance && CheckCanSee(i))
            {
                lowestDistance = distance;
                closest = i;
            }
        }
        return closest;
    }

    public void HaltCat()
    {
        StopAllCoroutines();
    }

    private bool CheckCanSee(gridItem item)
    {
        Vector3 direction = item.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        return hit.collider != null && hit.transform.GetComponent<gridItem>() == item;
    }

    public void StartCatMoving()
    {
        StartCoroutine(StartCatMovingCoroutine());
    }

    public void RestartCatPosition()
    {
        StopAllCoroutines();
        transform.position = startCatPos;
    }

    private IEnumerator StartCatMovingCoroutine()
    {
        gridItem closestObj = null;
        while ((closestObj = getClosestObject()) != null)
        {
            yield return StartCoroutine(MoveTowardsPosition(closestObj));
        }
    }

    private void AnimateCat(Vector3 walkDirection)
    {
        _catRenderer.flipX = walkDirection.x >= 0;
        if (walkDirection.y > 0)
        {
            _catAnimator.SetInteger("walk", 1);
        }
        else
        {
            _catAnimator.SetInteger("walk", 0);
        }
    }

    private IEnumerator MoveTowardsPosition(gridItem gridItem)
    {
        Vector3 finalPos = gridItem.transform.position;
        AnimateCat(finalPos - transform.position);

        while (transform.position != finalPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPos, Time.deltaTime * (speed + gridItem.additionalSpeed));
            yield return null;
        }
        gridItem.gameObject.SetActive(false);
    }
}
