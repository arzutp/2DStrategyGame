using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour, IPooledObject
{
    public string Name;
    public SpriteRenderer spriteRenderer;
    
    private Vector3 target;
    [SerializeField] NavMeshAgent navMeshAgent;

    public string GetName()
    {
        return Name;
    }
    public Sprite GetImage()
    {
        return spriteRenderer.sprite;
    }
    private void Update()
    {
        //setTargetPosition();
        //setAgentPosition();
    }

    public void SetTarget(Vector3 position)
    {
        navMeshAgent.destination = position;
    }
    //private void setTargetPosition()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    if(target != Vector3.zero)
    //        setAgentPosition();
    //}
    //private void setAgentPosition()
    //{
    //    navMeshAgent.SetDestination(new Vector2(target.x, target.y));
    //}
    public void OnObjectSpawn()
    {
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    public void Reset()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
