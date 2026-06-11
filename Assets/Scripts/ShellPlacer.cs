using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ShellPlacer : MonoBehaviour
{
    [SerializeField] private List<GameObject> shells = new List<GameObject>(); 
    [SerializeField] private int shellCount = 1000;
    [SerializeField] private GameObject bottomLeft;
    [SerializeField] private GameObject topRight;
    [SerializeField] private float minDistance = 0.5f; 

    private List<Vector2> points = new List<Vector2>();
    private Dictionary<Vector2Int, List<Vector2>> spatialGrid = new Dictionary<Vector2Int, List<Vector2>>();
    private float cellSize;

    void Start()
    {
        cellSize = minDistance; 
        GeneratePoints();
        SpawnShells();
    }

    
    public void GeneratePoints()
    {
        Vector2 blPos = bottomLeft.transform.position;
        Vector2 trPos = topRight.transform.position;

        int attempts = 0;
        int maxAttempts = shellCount * 10; 

        while (points.Count < shellCount && attempts < maxAttempts)
        {
            attempts++;

            float pointX = UnityEngine.Random.Range(blPos.x, trPos.x);
            float pointY = UnityEngine.Random.Range(blPos.y, trPos.y);
            Vector2 newPoint = new Vector2(pointX, pointY);

            if (IsFarEnough(newPoint))
            {
                points.Add(newPoint);
                AddToGrid(newPoint);
            }
        }

        if (points.Count < shellCount)
        {
            Debug.LogWarning($"Only placed {points.Count} shells due to spacing constraints.");
        }
    }

    
    private bool IsFarEnough(Vector2 point)
    {
        Vector2Int cell = GetCell(point);

        
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector2Int neighborCell = new Vector2Int(cell.x + x, cell.y + y);
                if (spatialGrid.TryGetValue(neighborCell, out List<Vector2> neighborPoints))
                {
                    foreach (Vector2 p in neighborPoints)
                    {
                        if (Vector2.Distance(p, point) < minDistance)
                            return false;
                    }
                }
            }
        }
        return true;
    }

    
    private void AddToGrid(Vector2 point)
    {
        Vector2Int cell = GetCell(point);
        if (!spatialGrid.ContainsKey(cell))
        {
            spatialGrid[cell] = new List<Vector2>();
        }
        spatialGrid[cell].Add(point);
    }

    
    private Vector2Int GetCell(Vector2 point)
    {
        return new Vector2Int(
            Mathf.FloorToInt(point.x / cellSize),
            Mathf.FloorToInt(point.y / cellSize)
        );
    }

   
    private void SpawnShells()
    {
        foreach (Vector2 point in points)
        {
            if (shells.Count == 0) return;

            GameObject prefab = shells[UnityEngine.Random.Range(0, shells.Count)];
            Instantiate(prefab, point, Quaternion.identity);
        }
    }
}