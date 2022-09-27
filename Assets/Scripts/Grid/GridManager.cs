using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] Tile tile;
    [SerializeField] Transform cam;

    public Dictionary<Vector2, Tile> Tiles = new Dictionary<Vector2, Tile>();
    private void Awake()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Tile spawnedTile = Instantiate(tile, new Vector2(x, y), Quaternion.identity, transform);
                spawnedTile.name = $"Tile {x} {y}";

                var isOffset = ((x + y) % 2 == 1);
                spawnedTile.Init(isOffset);

                Tiles.Add(new Vector2(x, y), spawnedTile);
            }
        }
        cam.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10f);
    }
}
