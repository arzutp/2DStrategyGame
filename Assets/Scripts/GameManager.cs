using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Structure buildingToPlace;
    public GridManager Grid;
    [SerializeField] CustomCursor CustomCursor;

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
                if (dist < 0.3f)
                {
                    nearestTile = tile.Value;
                }
            }

            if (nearestTile != null && nearestTile.isFull == false)
            {
                Instantiate(buildingToPlace, nearestTile.transform.position, Quaternion.identity, transform);
                buildingToPlace = null;
                nearestTile.isFull = true;
                CustomCursor.gameObject.SetActive(false);
                Cursor.visible = true;
            }
        }
    }
    public void DragBuilding(Structure structure)
    {
        CustomCursor.gameObject.SetActive(true);  //t�klad���m�z yerde input system i aktif ediyoruz
        CustomCursor.GetComponent<SpriteRenderer>().sprite = structure.GetComponent<SpriteRenderer>().sprite;   //butondaki objenin sprite ini kullanip hareketi sagliyoruz
        Cursor.visible = false;

        buildingToPlace = structure;
        //buildingToPlace = Instantiate(building);
        //Grid.gameObject.SetActive(true);
    }
}