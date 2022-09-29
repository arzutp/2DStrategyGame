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

    public void SetTarget(Vector3 position)
    {
        navMeshAgent.destination = position;
    }

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
