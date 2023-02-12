using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class Grid
{
    //To generate a grid, start position of the spawn, end position to take damage, how long, how big
    //should return an int[,] for the map of the tiles

    //function that phisically generates the grid with the input int[,] and has access to "building blocks"(array of prefabs)
    //bakes the navigation in the end

    public static int[,] GenerateGrid(Vector2 startPosition, Vector2 endPosition, Vector2 lenghtOfGrid, int cellSize, GameObject[] pathObjects)
    {
        if (!(((startPosition.x >= 0 && startPosition.x < lenghtOfGrid.x) && (startPosition.y >= 0 && startPosition.y < lenghtOfGrid.y)) &&
            ((endPosition.x >= 0 && endPosition.x < lenghtOfGrid.x) && (endPosition.y >= 0 && endPosition.y < lenghtOfGrid.y))))
        {
            Debug.LogWarning("The start position:" + startPosition.ToString() + " or the end position:" + endPosition.ToString() + " are not in the range of the grid!");
            return null;
        }

        int[,] grid = new int[(int)lenghtOfGrid.x, (int)lenghtOfGrid.y];

        grid[(int)startPosition.x, (int)startPosition.y] = 1;
        grid[(int)endPosition.x, (int)endPosition.y] = 1;

        Vector2 path = endPosition - startPosition;
        Vector2 currentPos = startPosition;
        GeneratePath(grid, path, currentPos);
        CreatePath(grid, pathObjects, startPosition, cellSize);
        return grid;
    }

    public static void CreatePath(int[,] grid, GameObject[] pathObjects, Vector2 startPosition, int cellSize)
    {
        GameObject groundParent = new GameObject("Ground");
        NavMeshSurface surface = null;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == 1)
                {
                    GameObject temp = GameObject.Instantiate(pathObjects[0], new Vector3( i, 0,  j) * cellSize, new Quaternion());
                    surface = temp.GetComponentInChildren<NavMeshSurface>();
                    temp.transform.parent = groundParent.transform;
                }
                else
                {
                    GameObject temp = GameObject.Instantiate(pathObjects[1], new Vector3( i, 0, j) * cellSize, new Quaternion());
                    temp.transform.parent = groundParent.transform;
                }

            }
        }
        surface.BuildNavMesh();
        surface.enabled = true;
    }

    private static void GeneratePath(int[,] grid, Vector2 path, Vector2 currentPos)
    {
        bool finishedOneCoord = false;
        int randomValue = 0;
        while (!path.Equals(Vector2.zero))
        {
            //Debug.Log("Path: " + path.ToString());
            if (!finishedOneCoord)
            {
                randomValue = Random.Range(0, 2);

                switch (randomValue)
                {
                    case 0:
                        if (path.x < 0)
                        {
                            currentPos.x--;
                            path.x++;
                            grid[(int)currentPos.x, (int)currentPos.y] = 1;
                        }
                        else
                        {
                            currentPos.x++;
                            path.x--;
                            grid[(int)currentPos.x, (int)currentPos.y] = 1;
                        }
                        //Debug.Log(currentPos.ToString());
                        break;
                    case 1:
                        if (path.y < 0)
                        {
                            currentPos.y--;
                            path.y++;
                            grid[(int)currentPos.x, (int)currentPos.y] = 1;
                        }
                        else
                        {
                            currentPos.y++;
                            path.y--;
                            grid[(int)currentPos.x, (int)currentPos.y] = 1;
                        }
                        //Debug.Log(currentPos.ToString());
                        break;
                }
            }
            else
            {
                if (path.x != 0)
                {
                    if (path.x < 0)
                    {
                        currentPos.x--;
                        path.x++;
                        grid[(int)currentPos.x, (int)currentPos.y] = 1;
                    }
                    else
                    {
                        currentPos.x++;
                        path.x--;
                        grid[(int)currentPos.x, (int)currentPos.y] = 1;
                    }
                    //Debug.Log(currentPos.ToString());
                }

                if (path.y != 0)
                {
                    if (path.y < 0)
                    {
                        currentPos.y--;
                        path.y++;
                        grid[(int)currentPos.x, (int)currentPos.y] = 1;
                    }
                    else
                    {
                        currentPos.y++;
                        path.y--;
                        grid[(int)currentPos.x, (int)currentPos.y] = 1;
                    }
                    //Debug.Log(currentPos.ToString());
                }
            }
            if (path.x == 0 || path.y == 0)
                finishedOneCoord = true;

        }
    }
}
