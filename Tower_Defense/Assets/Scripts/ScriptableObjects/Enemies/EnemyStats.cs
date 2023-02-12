using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy Stats")]
public class EnemyStats : ScriptableObject
{
    public int health = 0;
    public int defence = 0;

    public int gold = 0;

    public float speed = 0;

    public Color enemyColor;
}
