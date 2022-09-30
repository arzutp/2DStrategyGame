using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitMoveController : MonoBehaviour
{
    public List<Unit> UnitSelectedList;
    public Vector3 Target;

    private void Update()
    {
        moveToTarget();
        targetControl();
    }

    private void moveToTarget()
    {
        if (Target != Vector3.zero)
        {
            foreach (var item in UnitSelectedList)
            {
                item.SetTarget(Target);
            }
        }
    }

    private void targetControl()  //her seçtiðim unit ayný hedefe gitmesin kontrolu
    {
        for (int i = 0; i < UnitSelectedList.Count; i++)   //seçilen unitler ya da unit verilen hedefe ulaþtýðýnda hedef ve liste sýfýrlanýr
        {
            if (Vector3.Distance(UnitSelectedList[i].transform.position, Target) <= 1f)
            {
                if (i == UnitSelectedList.Count-1)
                    Target = Vector3.zero;
                UnitSelectedList.Remove(UnitSelectedList[i]);
                continue;
            }
        }
        
    }
}
