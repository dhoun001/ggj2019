using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : MonoBehaviour
{
    [SerializeField]
    private float timer = 2f;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (timer > 0){
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            UIController.Instance.ShowLoseMessage();
        }
    }

}
