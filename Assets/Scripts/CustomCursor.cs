using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] InputSystem inputSystem;

    void Update()
    {
        transform.position = inputSystem.MousePosition();
    }
}
