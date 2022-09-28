using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Structure
{
    [SerializeField] Unit Unit;
    PoolController poolController;

    public static Action<string, Sprite> OnUnitInformation;

    public void SetUnitInformation()
    {
        OnUnitInformation?.Invoke(Unit.GetName(), Unit.GetImage());
    }
    public override void OnObjectSpawn(string tag, Vector3 position, Quaternion rotation)
    {
        //poolController.UnitGetPool(tag, position, rotation);
    }
}
