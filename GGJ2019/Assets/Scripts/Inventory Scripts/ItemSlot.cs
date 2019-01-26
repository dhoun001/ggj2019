using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public bool isSlotted = false;
    public GameObject sourceObject;
    public Item sourceItem;
    public Text amountText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void UpdateQuantity(int amount)
    {
        amountText.text = amount.ToString();
    }
}
