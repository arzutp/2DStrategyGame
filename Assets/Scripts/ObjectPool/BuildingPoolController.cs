using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPoolController : ObjectPooler
{
    public override void Initialize()
    {
        base.Initialize();
        PoolAddObject();
        SetBuilding();
    }
    public void SetBuilding()
    {
        foreach (var building in Pools)
        {
            for (int i = 0; i < building.Size; i++)
            {
                structures.Add(building.Prefab);
            }
        }
    }
}
