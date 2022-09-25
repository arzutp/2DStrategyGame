using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Unit : MonoBehaviour, IPooledObject
{
    private Vector3 target;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }
    private void Update()
    {
        setTargetPosition();
        setAgentPosition();
    }
    private void setTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void setAgentPosition()
    {
        navMeshAgent.SetDestination(new Vector2(target.x, target.y));
    }
    public void OnObjectSpawn()
    {

    }
}
