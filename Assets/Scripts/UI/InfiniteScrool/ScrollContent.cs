using UnityEngine;
using UnityEngine.UI;

public class ScrollContent : MonoBehaviour
{
    [SerializeField] Sprite image;
    [SerializeField] PoolController poolController;
    #region Public Properties
    public float ItemSpacing { get { return itemSpacing; } }
    public float VerticalMargin { get { return verticalMargin; } }
    public float Width { get { return width; } }
    public float Height { get { return height; } }
    public float ChildWidth { get { return childWidth; } }
    public float ChildHeight { get { return childHeight; } }

    #endregion

    #region Private Members
    private RectTransform rectTransform;
    private RectTransform[] rtChildren;
    private float width, height;
    private float childWidth, childHeight;
    [SerializeField] float itemSpacing;
    [SerializeField] float verticalMargin;

    #endregion

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rtChildren = new RectTransform[rectTransform.childCount];

        for (int i = 0; i < rectTransform.childCount; i++)  //sirayla her butonu sahneye yerleştiriyor
        {
            rtChildren[i] = rectTransform.GetChild(i) as RectTransform; //butonları sahneye yerleştirirken bilgilerini de dolduruyoruz
            Structure structure = poolController.StructureRandomReturn(); //pool dan random building ve barrak objelerini alıyorum
            image = structure.GetImage();
            ButtonInformation buttonInformation = rtChildren[i].GetComponent<ButtonInformation>();
            buttonInformation.SetImage(image);

            buttonInformation.ButtonListener(structure);
        }

        height = rectTransform.rect.height - (2 * verticalMargin);
        childWidth = rtChildren[0].rect.width;
        childHeight = rtChildren[0].rect.height;
        InitializeContentVertical();

    }

    private void InitializeContentVertical()
    {
        float originY = 0 - (height * 0.5f);
        float posOffset = childHeight * 0.5f;
        for (int i = 0; i < rtChildren.Length; i++)
        {
            Vector2 childPos = rtChildren[i].localPosition;
            childPos.y = originY + posOffset + i * (childHeight + itemSpacing);
            rtChildren[i].localPosition = childPos;
        }
    }
}
