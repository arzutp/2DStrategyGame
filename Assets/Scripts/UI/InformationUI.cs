using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour
{
    [SerializeField] Text StructureText;
    [SerializeField] Image StructureImage;

    [SerializeField] Text UnitText;
    [SerializeField] Button UnitButton;

    private void OnEnable()
    {
        GameManager.OnStructureInformation += SetStructureInformation;
        Barrack.OnUnitInformation += SetUnitInformation;
        Building.OnUnitInformation += SetUnitInformation;
    }
    private void OnDisable()
    {
        GameManager.OnStructureInformation -= SetStructureInformation;
        Barrack.OnUnitInformation += SetUnitInformation;
        Building.OnUnitInformation += SetUnitInformation;
    }
    public void SetStructureInformation(string strText, Sprite img)
    {
        StructureText.text = strText;
        StructureImage.sprite = img;
    }

    public void SetUnitInformation(string strText, Sprite img)
    {
        UnitText.text = strText;
        UnitButton.image.sprite = img;
        ButtonListener();
    }

    public void ButtonListener()
    {
        UnitButton.onClick.AddListener(() => GameManager.Init.GetUnitFromPool());
    }
}
