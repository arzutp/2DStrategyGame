using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Structure
{
    [SerializeField] Unit Unit;
    public Transform UnitSpawnPoint;
    
    public static Action<string, Sprite> OnUnitInformation;

    public override void SetUnitInformation()
    {
        base.SetUnitInformation();
        OnUnitInformation?.Invoke(Unit.GetName(), Unit.GetImage());
    }
    public override void OnObjectSpawn()
    {
        // PoolController.Init.UnitGetPool(Unit.Name, UnitSpawnPoint.position, Quaternion.identity);
        //poolController.UnitGetPool(Unit.tag, position, rotation);
    }

    public void OnUnitSpawn()
    {
        float rand = UnityEngine.Random.Range(0, 0.5f);
        PoolController.Init.UnitGetPool(Unit.Name, UnitSpawnPoint.position+new Vector3(rand,rand,0), Quaternion.identity);
    }
}
