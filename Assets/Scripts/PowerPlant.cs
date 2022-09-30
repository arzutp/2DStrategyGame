using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerPlant : Structure
{
    public static Action<string, Sprite> OnUnitInformation;
    public override void SetUnitInformation()
    {
        base.SetUnitInformation();
        OnUnitInformation?.Invoke(null, null);
    }
}
