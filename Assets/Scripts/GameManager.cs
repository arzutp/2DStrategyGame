using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enums;

public class GameManager : MonoBehaviour
{
    [SerializeField] GridManager Grid;
    [SerializeField] CustomCursor CustomCursor;
    [SerializeField] PoolController poolController;
    [SerializeField] Camera cam;

    Structure barrakStructure;
    Structure buildingToPlace;

    public static Action<string, Sprite> OnStructureInformation;

    public static GameManager Init;

    public void Awake()
    {
        Init = this;
    }
    private void Update()
    {
        placeToBuilding();
    }

    private void placeToBuilding()
    {
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)  
        {
            Tile nearestTile = null;

            buildingToPlace.transform.position = Input.mousePosition;
            foreach (KeyValuePair<Vector2, Tile> tile in Grid.Tiles) //seçtiðim objeye yakýn tile a bulmaya çalýþýyorum
            {
                float dist = Vector2.Distance(tile.Key, cam.ScreenToWorldPoint(Input.mousePosition));
                if (dist < 0.4f)
                {
                    nearestTile = tile.Value;
                }
            }

            if (nearestTile != null && nearestTile.isFull == false)  //bulunduðum tile boþ ise oraya objeyi yerleþtiriyorum
            {
                poolController.GetPool(buildingToPlace,buildingToPlace.Name, nearestTile.transform.position, Quaternion.identity);
                barrakStructure = buildingToPlace;
                barrakStructure.transform.position = nearestTile.transform.position;
                buildingToPlace = null;
                nearestTile.SetIsFull(true);
                CustomCursor.SetSprite(null);
                CustomCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }
    
    public void DragBuilding(Structure structure)
    {
        CustomCursor.gameObject.SetActive(true);  //týkladýðýmýz yerde input system i aktif ediyoruz
        CustomCursor.gameObject.transform.localScale = structure.transform.localScale; //custom cursor bizim gecici objemiz gibi islev goruyor objenin ozelliklerini o yuzden custom cursor a atýyorum
        CustomCursor.SetSprite(structure.GetImage());  //butondaki objenin sprite ini kullanip hareketi sagliyoruz
        Cursor.visible = false;
        StructureInformation(structure);
        buildingToPlace = structure;
    }

    public void StructureInformation(Structure structure)
    {
        OnStructureInformation?.Invoke(structure.GetName(), structure.GetImage());  //Information kýsmýna bilgileri yazdýrmak için action kullandým
        if (structure.Type == Objects.Barrak)
        {
            structure.GetComponent<Barrack>().SetUnitInformation();
        }
        else
            structure.GetComponent<Building>().SetUnitInformation();
    }

    public void GetUnitFromPool()
    {
        if (barrakStructure.Type == Objects.Barrak)
        {
            barrakStructure.GetComponent<Barrack>().OnUnitSpawn();
        }
    }
}
