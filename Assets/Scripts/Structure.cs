using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
//building ve barrak i�in genel s�n�f
public abstract class Structure : MonoBehaviour, IPooledObject
{
    public Objects Type;
    public string Name;
    public SpriteRenderer spriteRenderer;
    public string GetName()
    {
        return Name;
    }
    public Sprite GetImage()
    {
        return spriteRenderer.sprite;
    }
    public void OnObjectSpawn()
    {
        
    }

    public void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
