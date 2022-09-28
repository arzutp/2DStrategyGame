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
            foreach (KeyValuePair<Vector2, Tile> tile in Grid.Tiles) //se�ti�im objeye yak�n tile a bulmaya �al���yorum
            {
                float dist = Vector2.Distance(tile.Key, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < 0.4f)
                {
                    nearestTile = tile.Value;
                }
            }

            if (nearestTile != null && nearestTile.isFull == false)  //bulundu�um tile bo� ise oraya objeyi yerle�tiriyorum
            {
                poolController.GetPool(buildingToPlace,buildingToPlace.Name, nearestTile.transform.position, Quaternion.identity);
                buildingToPlace = null;
                nearestTile.SetIsFull(true);
                CustomCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }
    
    public void DragBuilding(Structure structure)
    {
        CustomCursor.gameObject.SetActive(true);  //t�klad���m�z yerde input system i aktif ediyoruz
        CustomCursor.gameObject.transform.localScale = structure.transform.localScale; //custom cursor bizim gecici objemiz gibi islev goruyor objenin ozelliklerini o yuzden custom cursor a at�yorum
        CustomCursor.SetSprite(structure.GetImage());  //butondaki objenin sprite ini kullanip hareketi sagliyoruz
        Cursor.visible = false;
        OnStructureInformation?.Invoke(structure.GetName(), structure.GetImage());  //Information k�sm�na bilgileri yazd�rmak i�in action kulland�m
        if (structure.Type == Objects.Barrak)
        {
            structure.GetComponent<Barrack>().SetUnitInformation();
            barrakStructure = structure;
        }
        else
            structure.GetComponent<Building>().SetUnitInformation();
        buildingToPlace = structure;
    }

    public void GetUnitFromPool()
    {
        if (barrakStructure != null)
        {
            barrakStructure.GetComponent<Barrack>().OnUnitSpawn();
        }
    }
}
