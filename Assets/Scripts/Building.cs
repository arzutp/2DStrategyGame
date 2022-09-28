using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Structure
{

    public static Action<string, Sprite> OnUnitInformation;

    public void SetUnitInformation()
    {
        OnUnitInformation?.Invoke(null,null);
    }
}
