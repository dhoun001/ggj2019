using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    [SerializeField]
    private float timer = 2f;
    catBehavior instance = null;
    private float catSpeed = 0;
    // Update is called once per frame

    void Awake()
    {
        instance = FindObjectOfType<catBehavior>();
        catSpeed = instance.speed;
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "cat")
        {
            instance.speed = instance.speed / 2;
            while (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            if (timer <= 0)
            {
                instance.speed = catSpeed;
                UIController.Instance.ShowLoseMessage();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        instance.speed = catSpeed;
    }

}
