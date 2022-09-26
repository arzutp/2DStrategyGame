using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInformation : MonoBehaviour
{
    public Image buttonImage;

    public void SetImage(Sprite image)
    {
        buttonImage.sprite = image;
    }

    public void ButtonListener(Structure structure)
    {
        GetComponent<Button>().onClick.AddListener(() => GameManager.Init.DragBuilding(structure));
    }
}
