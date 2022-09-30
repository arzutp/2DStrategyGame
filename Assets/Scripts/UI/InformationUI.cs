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
        Structure.OnUnitInformation += SetUnitInformation;
        Barrack.OnMaxUnitInformation += UnitCountInformation;
    }
    private void OnDisable()
    {
        GameManager.OnStructureInformation -= SetStructureInformation;
        Structure.OnUnitInformation -= SetUnitInformation;
        Barrack.OnMaxUnitInformation -= UnitCountInformation;
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

    public void UnitCountInformation()
    {
        maxText.gameObject.SetActive(true);
        StartCoroutine(MaxText());
    }

    IEnumerator MaxText()
    {
        yield return new WaitForSeconds(0.5f);
        maxText.gameObject.SetActive(false);
    }
}
