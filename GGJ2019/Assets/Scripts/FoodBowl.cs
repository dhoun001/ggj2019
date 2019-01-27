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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "cat")
        {
            UIController.Instance.ShowWinMessage();
        }
    }
}
