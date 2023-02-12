using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Stats")]
public class TowerStats : ScriptableObject
{
    public string towerType;
    public float damage = 0;
    public float attackSpeed = 0;

    public int buildingCost = 0;
    public int upgradeCostDamage = 0;
    public int upgradeCostSpeed = 0;

    [Header("Upgrading stats")]
    public float damageUpgradeValue;
    public float attackSpeedUpgradeValue;
}
