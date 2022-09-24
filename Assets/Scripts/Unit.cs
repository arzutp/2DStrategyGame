using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IPooledObject
{
    public float upForce = 5f;
    public float sideForce = 8f;

    public void OnObjectSpawn()  
    {
        //float xForce = Random.Range(-sideForce, sideForce);
        //float yForce = Random.Range(upForce / 2f, upForce);

        //transform.position = new Vector2(xForce, yForce);
    }
}
