using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour
{
    [SerializeField]
    private bool sortOnUpdate = false;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SortLayer();
    }

    private void Update()
    {
        if (sortOnUpdate)
            SortLayer();
    }

    private void SortLayer()
    {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * 100) * -1;
    }
}
