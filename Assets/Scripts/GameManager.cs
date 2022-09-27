using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Structure buildingToPlace;
    [SerializeField] GridManager Grid;
    [SerializeField] CustomCursor CustomCursor;
    [SerializeField] PoolController poolController;

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
            foreach (KeyValuePair<Vector2, Tile> tile in Grid.Tiles) //seçtiðim objeye yakýn tile a bulmaya çalýþýyorum çalýþýyorum
            {
                float dist = Vector2.Distance(tile.Key, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < 0.3f)
                {
                    nearestTile = tile.Value;
                }
            }

            if (nearestTile != null && nearestTile.isFull == false)  //bulunduðum tile boþ ise oraya objeyi yerleþtiriyorum
            {
                poolController.GetPool(buildingToPlace,buildingToPlace.Name, nearestTile.transform.position, Quaternion.identity);
                //buildingToPlace.GetComponent<ObjectPooler>().SpawnFromPool(buildingToPlace.Name, nearestTile.transform.position, Quaternion.identity);
                //Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity, transform);
                buildingToPlace = null;
                nearestTile.isFull = true;
                CustomCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }

    
    public void DragBuilding(Structure structure)
    {
        CustomCursor.gameObject.SetActive(true);  //týkladýðýmýz yerde input system i aktif ediyoruz
        CustomCursor.SetSprite(structure.GetImage());  //butondaki objenin sprite ini kullanip hareketi sagliyoruz
        Cursor.visible = false;
        OnStructureInformation?.Invoke(structure.GetName(), structure.GetImage());
        buildingToPlace = structure;
        //buildingToPlace = Instantiate(building);
        //Grid.gameObject.SetActive(true);
    }
}
