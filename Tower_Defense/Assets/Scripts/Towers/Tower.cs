using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tower : MonoBehaviour, IPlaceable
{
    public TowerStats stats;
    public int level;

    public float damage;
    public float attackSpeed;

    public int upgradeCostDamage;

    public int upgradeCostSpeed;
    public float sellValue;
    public int buildingCost
    {
        get { return stats.buildingCost; }
        set { }
    }


    private void OnEnable()
    {
        upgradeCostDamage = stats.upgradeCostDamage;
        upgradeCostSpeed = stats.upgradeCostSpeed;
        sellValue = (buildingCost / 100) * 70;
    }
    public void UpgradeDamage()
    {
        damage += stats.damageUpgradeValue;
        sellValue += (upgradeCostDamage / 100) * 70;
        upgradeCostDamage += (upgradeCostDamage / 100) * 20;
    }

    public void UpgradeAS()
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

    public void Sell()
    {
        Player.Instance.Coins.UpdateCoins((int)sellValue);
        Destroy(gameObject);
    }


    public virtual IEnumerator Attack(List<GameObject> enemies)
    {
        yield break;
    }
}
