using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
//building ve barrak için genel sýnýf
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
    public virtual void OnObjectSpawn(string tag, Vector3 position, Quaternion rotation)
    {
        
    }

    public void Reset()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
