using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantPoolController : ObjectPooler
{
    public override void Initialize()
    {
        base.Initialize();
        PoolAddObject();
        SetBuilding();
    }
    public void SetBuilding()
    {
        foreach (var powerPlant in Pools)
        {
            for (int i = 0; i < powerPlant.Size; i++)
            {
                structures.Add(powerPlant.Prefab);
            }
        }
    }
}
