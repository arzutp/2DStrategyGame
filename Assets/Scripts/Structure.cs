using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Structure : MonoBehaviour, IPooledObject
{
    [SerializeField] string Name;
    [SerializeField] Image Image;

    public void OnObjectSpawn()
    {
        throw new System.NotImplementedException();
    }
}
