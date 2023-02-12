using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/Entities to Spawn")]
public class Entities : ScriptableObject
{
    [Range(0f, 100f)]public float[] chancesToSpawn;
    public GameObject[] entities;
}
