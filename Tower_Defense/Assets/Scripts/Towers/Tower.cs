using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour, IPlaceable
{
    public TowerStats stats;
    public int level;

    public float damage;
    public float attackSpeed;

    public int buildingCost
    {
        get { return stats.buildingCost; }
        set { }
    }

    public int upgradeCostDamage { 
        get
        {
            return stats.upgradeCostDamage;
        }
        set{ }
    }

    public int upgradeCostSpeed
    {
        get
        {
            return stats.upgradeCostSpeed;
        }
        set { }
    }

    public int sellValue
    {
        get
        {
            return (stats.buildingCost /100) * 70;
        }
        set{ }
    }


    private void Start()
    {
    }

    void IPlaceable.UpgradeDamage()
    {
        damage += stats.damageUpgradeValue;
        sellValue += (upgradeCostDamage / 100) * 70;
        upgradeCostDamage += (upgradeCostDamage / 100) * 20;
    }

    void IPlaceable.UpgradeAS()
    {
        if(attackSpeed <= 1)
        {
            attackSpeed = 1;
            sellValue += (upgradeCostSpeed / 100) * 70;
            upgradeCostSpeed = 0;
        }
        else
        {
            attackSpeed += stats.attackSpeedUpgradeValue;
            sellValue += (upgradeCostSpeed / 100) * 70;
            upgradeCostSpeed += (upgradeCostSpeed / 100) * 20;
        }
    }

    void IPlaceable.Sell()
    {
        Player.Instance.Coins.UpdateCoins(sellValue);
        Destroy(gameObject);
    }


    public virtual IEnumerator Attack(GameObject enemy)
    {
        yield break;
    }
}
