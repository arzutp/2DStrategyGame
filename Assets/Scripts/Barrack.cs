using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Structure
{
    [SerializeField] Unit Unit;
    public Transform UnitSpawnPoint;

    public static Action<string, Sprite> OnUnitInformation;

    public void SetUnitInformation()
    {
        OnUnitInformation?.Invoke(Unit.GetName(), Unit.GetImage());
    }
    public override void OnObjectSpawn()
    {
        // PoolController.Init.UnitGetPool(Unit.Name, UnitSpawnPoint.position, Quaternion.identity);
        //poolController.UnitGetPool(Unit.tag, position, rotation);
    }

    public void OnUnitSpawn()
    {
        PoolController.Init.UnitGetPool(Unit.Name, UnitSpawnPoint.position, Quaternion.identity);
    }

}
