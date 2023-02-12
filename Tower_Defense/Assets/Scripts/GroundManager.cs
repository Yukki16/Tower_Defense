using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] GroundSpawn spawns;
    // Start is called before the first frame update
    [SerializeField] GameObject[] paths;

    void Start()
    {
        Grid.GenerateGrid(spawns.startPosition, spawns.endPosition, spawns.lenghtOfGrid, spawns.gridSize, paths);
    }

    
}
