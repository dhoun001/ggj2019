using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : gridItem
{
    public override void OnArrive()
    {
        //TODO: lose level
        UIController.Instance.ShowLoseMessage();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "cat")
        {
            UIController.Instance.ShowLoseMessage();
        }
    }
}
