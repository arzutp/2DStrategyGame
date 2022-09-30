using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PowerPlant : Structure
{
    public override void SetUnitInformation()
    {
        base.SetUnitInformation();
        OnUnitInformation?.Invoke(null, null);
    }
}
