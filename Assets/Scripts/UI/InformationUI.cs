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
    [SerializeField] Image maxText;

    private void OnEnable()
    {
        GameManager.OnStructureInformation += SetStructureInformation;
        Barrack.OnUnitInformation += SetUnitInformation;
        Building.OnUnitInformation += SetUnitInformation;
        PowerPlant.OnUnitInformation += SetUnitInformation;
    }
    private void OnDisable()
    {
        GameManager.OnStructureInformation -= SetStructureInformation;
        Barrack.OnUnitInformation += SetUnitInformation;
        Building.OnUnitInformation += SetUnitInformation;
        PowerPlant.OnUnitInformation -= SetUnitInformation;
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
        RemoveButtonListener();
        ButtonListener();
    }

    public void ButtonListener()
    {
        UnitButton.onClick.AddListener(() => GameManager.Init.GetUnitFromPool());
    }

    public void RemoveButtonListener()
    {
        UnitButton.onClick.RemoveAllListeners();
    }
}
