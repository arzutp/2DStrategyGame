using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            objectPooler.SpawnFromPool("Unit", Input.mousePosition, Quaternion.identity);
    }
}
