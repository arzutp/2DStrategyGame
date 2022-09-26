using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] BuildingPoolController buildingPool;
    [SerializeField] BarrackPoolController barrackPool;
    [SerializeField] UnitSpawnerController unitSpawner;

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        buildingPool.Initialize();
        barrackPool.Initialize();
        unitSpawner.Initialize();
    }

    public Structure StructureRandomReturn()
    {
        float rand = Random.Range(0, 2);
        if(rand == 0)
        {
            int barrackIndex = Random.Range(0, barrackPool.structures.Count);
            return barrackPool.structures[barrackIndex].GetComponent<Structure>();

        }
        int buildingIndex = Random.Range(0, buildingPool.structures.Count);
        return buildingPool.structures[buildingIndex].GetComponent<Structure>();
    }
}
