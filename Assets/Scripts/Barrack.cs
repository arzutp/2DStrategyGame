using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Structure
{
    [SerializeField] Unit Unit;
    public Transform UnitSpawnPoint;
    
    int maxUnitCount;

    public static Action OnMaxUnitInformation;

    public override void SetUnitInformation()
    {
        base.SetUnitInformation();
        OnUnitInformation?.Invoke(Unit.GetName(), Unit.GetImage());
    }
    bool unitCountCheck;
    public override void OnObjectSpawn()
    {
        unitCountCheck = true;
    }

    public void OnUnitSpawn()
    {
        if (unitCountCheck)
        {
            maxUnitCount = 0;
            unitCountCheck = false;
        }
       
        float rand = UnityEngine.Random.Range(0, 0.5f);
        if (maxUnitCount <15)
        {
            PoolController.Init.UnitGetPool(Unit.Name, UnitSpawnPoint.position + new Vector3(rand, rand, 0), Quaternion.identity);
            maxUnitCount++;
            
        }
        else 
            OnMaxUnitInformation?.Invoke();
    }
}
