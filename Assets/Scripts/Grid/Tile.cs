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
    }

    private void OnMouseExit()
    {
        highligth.SetActive(false);
    }
}
