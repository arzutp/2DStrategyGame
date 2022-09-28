using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] BuildingPoolController buildingPool;
    [SerializeField] BarrackPoolController barrackPool;
    [SerializeField] UnitSpawnerController unitSpawner;
    public static PoolController Init;

    public void Awake()
    {
        Init = this;
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
    
    public void GetPool(Structure structure, string tag, Vector3 position, Quaternion rotation)
    {
        if(structure.Type == Enums.Objects.Barrak)
        {
            barrackPool.SpawnFromPool(tag, position, rotation);
        }
        if(structure.Type == Enums.Objects.Building)
        {
            buildingPool.SpawnFromPool(tag, position, rotation); 
        }
    }

    public void UnitGetPool(string tag, Vector3 position, Quaternion rotation)
    {
        //if(unitSpawner.poolDictionary[tag].Count > unitCount)
        unitSpawner.SpawnFromPool(tag, position, rotation);
    }

}
