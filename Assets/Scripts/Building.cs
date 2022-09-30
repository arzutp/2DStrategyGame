using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure
{
    public override void SetUnitInformation()
    {
        base.SetUnitInformation();
        OnUnitInformation?.Invoke(null,null);
    }
}
