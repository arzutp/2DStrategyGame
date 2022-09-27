using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isFull;

    [SerializeField] Color baseColor, offsetColor;
    [SerializeField] SpriteRenderer renderer;
    [SerializeField] GameObject highligth;

    public void Init(bool isOffset)
    {
        renderer.material.color = isOffset ? offsetColor : baseColor;
    }

    private void OnMouseEnter()
    {
        highligth.SetActive(true);
        if (isFull)
            highligth.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, 0.5f);
    }

    private void OnMouseExit()
    {
        highligth.SetActive(false);
    }

    public void SetIsFull(bool isFull)
    {
        this.isFull = isFull;
    }
}
