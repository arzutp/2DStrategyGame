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
    public override void OnObjectSpawn()
    {
        maxUnitCount = 15;
    }

    public void OnUnitSpawn()
    {
        float rand = UnityEngine.Random.Range(0, 0.5f);
        if (maxUnitCount > 0)
        {
            PoolController.Init.UnitGetPool(Unit.Name, UnitSpawnPoint.position + new Vector3(rand, rand, 0), Quaternion.identity);
            maxUnitCount--;
            print(maxUnitCount);
        }
        else 
            OnMaxUnitInformation?.Invoke();
    }
}
