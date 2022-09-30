using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionController : MonoBehaviour
{
    [SerializeField] UnitMoveController unitController;
    [SerializeField] LayerMask layerMask;
    [SerializeField] LayerMask structureLayerMask;
    [SerializeField] Camera cam;
    [SerializeField] InputSystem inputSystem;

    private void Update()
    {
        onUnitSelect();
        targetSelect();
        structureSelect();
    }

    private void onUnitSelect()
    {
        //2D ile yapt���mda barrack collider i yuzunden uniti alg�lam�yordu o yuzden bu sekilde kulland�m
        if (inputSystem.LeftMouseButton())   //unit se�me i�lemini raycast ile yapt�m
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out raycastHit, 1000f, layerMask))
            {
                var item = raycastHit.collider.gameObject.transform;
                if(!unitController.UnitSelectedList.Contains(item.GetComponent<Unit>()))
                    unitController.UnitSelectedList.Add(item.GetComponent<Unit>());
            }
        }
    }

    //hedef secme isleminde mouse posizyonunu baz ald�m
    private void targetSelect()
    {
        if (inputSystem.RightMouseButton())
        {
            Vector2 tempTarget = inputSystem.MousePosition();
            unitController.Target = new Vector3(tempTarget.x, tempTarget.y, 0.4f);
        }
    }

    private void structureSelect()  //sahnede ki objenin bilgilerini tekrardan g�rmek i�in
    {
        if (inputSystem.LeftMouseButton())
        {
            Ray worldPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint.origin, worldPoint.direction,Mathf.Infinity, structureLayerMask);
            if (hit)
            {
                 GameManager.Init.StructureInformation(hit.collider.GetComponent<Structure>());
            }
        }
    }
}
