using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationUI : MonoBehaviour
{
    [SerializeField] Text StructureText;
    [SerializeField] Image StructureImage;

    [SerializeField] Text UnitText;
    [SerializeField] Image UnitImage;

    private void OnEnable()
    {
        GameManager.OnStructureInformation += SetStructureInformation;
    }
    private void OnDisable()
    {
        GameManager.OnStructureInformation -= SetStructureInformation;
    }
    public void SetStructureInformation(string strText, Sprite img)
    {
        StructureText.text = strText;
        StructureImage.sprite = img;
    }

    public void SetUnitInformation(string strText, Sprite img)
    {
        UnitText.text = strText;
        UnitImage.sprite = img;
    }
}
