using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//building ve barrak i�in genel s�n�f
public abstract class Structure : MonoBehaviour, IPooledObject
{
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
        throw new System.NotImplementedException();
    }

    public void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
