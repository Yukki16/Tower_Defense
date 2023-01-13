using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] Vector2 startPosition = Vector2.zero;
    [SerializeField] Vector2 endPosition = new Vector2(9, 5);

    [SerializeField] Vector2 lenghtOfGrid = new Vector2(10, 10);
    [SerializeField] int gridSize = 10;
    // Start is called before the first frame update
    [SerializeField] GameObject[] paths;
    void Start()
    {
        Grid.GenerateGrid(startPosition, endPosition, lenghtOfGrid, gridSize, paths);
    }


}
