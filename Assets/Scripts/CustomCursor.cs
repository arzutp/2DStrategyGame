using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] InputSystem inputSystem;
    // Update is called once per frame
    void Update()
    {
        transform.position = inputSystem.MousePosition();
    }
}
