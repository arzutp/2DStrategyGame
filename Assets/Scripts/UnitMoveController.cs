using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class UnitMoveController : MonoBehaviour
{
    public List<Unit> unitSelectedList;
    public Vector3 target;

    private void Update()
    {
        MoveToTarget();
    }

    public void MoveToTarget()
    {
        foreach (var item in unitSelectedList)
        {
            if (target != Vector3.zero)
            {
                item.SetTarget(target);
            }
        }
    }
}
