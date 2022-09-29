using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionController : MonoBehaviour
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
        if (inputSystem.LeftMouseButton())
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out raycastHit, 1000f, layerMask))
            {
                var item = raycastHit.collider.gameObject.transform;
                if(!unitController.unitSelectedList.Contains(item.GetComponent<Unit>()))
                    unitController.unitSelectedList.Add(item.GetComponent<Unit>());
                //unitController.target = raycastHit.collider.gameObject.transform;
            }
        }
    }

    private void targetSelect()
    {
        if (inputSystem.RightMouseButton())
        {
            Vector3 tempTarget = cam.ScreenToWorldPoint(Input.mousePosition);
            unitController.target = new Vector3(tempTarget.x, tempTarget.y, 0.4f);
        }
    }

    private void structureSelect()
    {
        if (inputSystem.LeftMouseButton())
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, structureLayerMask);

            if (hit.collider != null)
            {
                 GameManager.Init.StructureInformation(hit.collider.GetComponent<Structure>());
                //GameManager.Init.DragBuilding(hit.collider.GetComponent<Structure>());
            }
        }
    }
}
