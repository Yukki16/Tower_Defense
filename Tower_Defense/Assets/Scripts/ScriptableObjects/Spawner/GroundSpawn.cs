using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Spawns")]
public class GroundSpawn : ScriptableObject
{
    [Header("Grid properties")]
    public Vector2 startPosition;
    public Vector2 endPosition;
    public Vector2 lenghtOfGrid;
    public int gridSize;

    [Header("Wave properties")]
    public int numberOfWaves;
    public int intitialWaveSize;

    public int waveTime;
}
