using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    public Vector2 MousePosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }

    public bool LeftMouseButton()
    {
        if (Input.GetMouseButtonDown(0))
            return true;
        return false;
    }

    public bool RightMouseButton()
    {
        if (Input.GetMouseButtonDown(1))
            return true;
        return false;
    }
}
