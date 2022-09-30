using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure
{
    public static Action<string, Sprite> OnUnitInformation;

    public override void SetUnitInformation()
    {
        base.SetUnitInformation();
        OnUnitInformation?.Invoke(null,null);
    }
}
