using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Structure
{
    [SerializeField] Unit Unit;
    bool isActive;
    float timer;
    int unitCount;

    public static Action<string, Sprite> OnUnitInformation;

    private void Update()
    {
        if (isActive)
        {
            if(timer <= 2)
            {
                timer += Time.deltaTime;
            }
            else
            {
                PoolController.Init.UnitGetPool(unitCount,Unit.Name, Vector3.zero, Quaternion.identity);
                timer = 0;
                unitCount++;
            }
        }
    }
    public void SetUnitInformation()
    {
        OnUnitInformation?.Invoke(Unit.GetName(), Unit.GetImage());
    }
    public override void OnObjectSpawn(bool isActive)
    {
        this.isActive = isActive;
        timer = 0;
        unitCount = 0;
        //poolController.UnitGetPool(Unit.tag, position, rotation);
    }

}
