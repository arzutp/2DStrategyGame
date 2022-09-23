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
            objectPooler.SpawnFromPool("Unit", Camera.main.ScreenToWorldPoint( new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f)), Quaternion.identity, transform);
    }
}
