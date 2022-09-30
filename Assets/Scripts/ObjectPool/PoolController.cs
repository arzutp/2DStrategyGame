using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] BuildingPoolController buildingPool;
    [SerializeField] BarrackPoolController barrackPool;
    [SerializeField] UnitSpawnerController unitSpawner;
    [SerializeField] PowerPlantPoolController powerPlantPool;
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
        powerPlantPool.Initialize();
    }

    public Structure StructureRandomReturn()
    {
        float rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                int barrackIndex = Random.Range(0, barrackPool.structures.Count);
                return barrackPool.structures[barrackIndex].GetComponent<Structure>();
            case 1:
                int buildingIndex = Random.Range(0, buildingPool.structures.Count);
                return buildingPool.structures[buildingIndex].GetComponent<Structure>();
            case 2:
                int powerPlantIndex = Random.Range(0, powerPlantPool.structures.Count);
                return powerPlantPool.structures[powerPlantIndex].GetComponent<Structure>();
            default:
                break;
        }
        return null;
        
    }
    
    public void GetPool(Structure structure, string tag, Vector3 position, Quaternion rotation)
    {
        if(structure.Type == Enums.Objects.Barrak)
        {
            barrackPool.SpawnFromPool(tag, position, rotation);
            print(structure.name);
        }
        if(structure.Type == Enums.Objects.Building)
        {
            buildingPool.SpawnFromPool(tag, position, rotation); 
        }
        if (structure.Type == Enums.Objects.PowerPlant)
        {
            powerPlantPool.SpawnFromPool(tag, position, rotation);
            print("bjkb");
        }
    }

    public void UnitGetPool(string tag, Vector3 position, Quaternion rotation)
    {
        //if(unitSpawner.poolDictionary[tag].Count > unitCount)
        unitSpawner.SpawnFromPool(tag, position, rotation);
    }

}
