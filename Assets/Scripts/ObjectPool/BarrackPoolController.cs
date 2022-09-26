using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackPoolController : ObjectPooler
{
    public override void Initialize()
    {
        base.Initialize();
        PoolAddObject();
        SetBarrack();
    }
    public void SetBarrack()
    {
        foreach (var barrack in Pools)
        {
            for (int i = 0; i < barrack.Size; i++)
            {
                structures.Add(barrack.Prefab);
            }
        }
    }
}
