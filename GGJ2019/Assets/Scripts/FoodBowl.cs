using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBowl : gridItem
{
    public override void OnArrive()
    {
        //TODO: show level win ui
        UIController.Instance.ShowWinMessage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("collide");
        if (collision.gameObject.name == "cat")
        {
            UIController.Instance.ShowWinMessage();
        }
    }
}
