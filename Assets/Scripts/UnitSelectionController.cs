using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionController : MonoBehaviour
{
    [SerializeField] UnitMoveController unitController;
    [SerializeField] LayerMask layerMask;
    [SerializeField] Camera cam;


    private void Update()
    {
        onUnitSelect();
        targetSelect();
    }

    private void onUnitSelect()
    {
        if (Input.GetMouseButtonDown(0))
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
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 tempTarget = cam.ScreenToWorldPoint(Input.mousePosition);
            unitController.target = new Vector3(tempTarget.x, tempTarget.y, 0.4f);
        }
    }
}
