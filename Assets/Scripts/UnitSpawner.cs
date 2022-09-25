using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;
public class UnitSpawner : ObjectPooler
{
    private void Start()
    {
        PoolAddObject();
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
            SpawnFromPool(Units.Swordman.ToString(), Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, 10f)), Quaternion.identity);
    }
}
