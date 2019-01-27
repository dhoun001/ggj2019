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

    private bool triggered = false;
    void Update()
    {
        if (triggered)
            timer -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "cat")
        {
            instance.speed = instance.speed / 2;
            while (timer > 0)
            {
                triggered = true;
            }
            if (timer <= 0)
            {
                triggered = false;
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
