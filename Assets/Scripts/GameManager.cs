using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Building buildingToPlace;
    public GridManager Grid;
    [SerializeField] InputSystem inputSystem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && buildingToPlace != null)
        {
            Tile nearestTile = null;
            float nearestDistance = float.MaxValue;
            buildingToPlace.transform.position = Input.mousePosition;
            foreach (KeyValuePair<Vector2, Tile> tile in Grid.Tiles)
            {
                float dist = Vector2.Distance(tile.Key, Camera.main.ScreenToWorldPoint(Input.mousePosition));
                if (dist < 1.0f)
                {
                    //nearestDistance = dist;
                    nearestTile = tile.Value;
                }
            }

            if (nearestTile != null && nearestTile.isFull == false)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity, transform);
                buildingToPlace = null;
                nearestTile.isFull = true;
                inputSystem.gameObject.SetActive(false);
                Cursor.visible = true;

            }
        }
    }
    public void DragBuilding(Building building)
    {
        inputSystem.gameObject.SetActive(true);  //týkladýðýmýz yerde input system i aktif ediyoruz
        inputSystem.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;   //butondaki objenin sprite ini kullanip hareketi sagliyoruz
        Cursor.visible = false;

        buildingToPlace = building;
        //buildingToPlace = Instantiate(building);
        //Grid.gameObject.SetActive(true);
    }
}
