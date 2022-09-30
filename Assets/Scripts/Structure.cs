using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
using System;

//building ve barrak için genel sýnýf
public abstract class Structure : MonoBehaviour, IPooledObject
{
    public Objects Type;
    public string Name;
    public SpriteRenderer spriteRenderer;

    public static Action<string, Sprite> OnUnitInformation;

    public string GetName()
    {
        return Name;
    }
    public Sprite GetImage()
    {
        return spriteRenderer.sprite;
    }
    public virtual void OnObjectSpawn()
    {
        
    }

    public virtual void SetUnitInformation()
    {
       
    }

    public void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tile"))
        {
            collision.GetComponent<Tile>().SetIsFull(true);
        }
    }
}
