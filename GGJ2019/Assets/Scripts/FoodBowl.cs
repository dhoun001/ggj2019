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
}
