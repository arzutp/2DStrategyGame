using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] InputSystem inputSystem;
    [SerializeField] SpriteRenderer spriteRenderer;
    void Update()
    {
        transform.position = inputSystem.MousePosition();
    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
