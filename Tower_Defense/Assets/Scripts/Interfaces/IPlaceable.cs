using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaceable
{
    public void UpgradeDamage();
    void UpgradeAS();
    void Sell();

    int buildingCost { get; set; }
    int upgradeCostDamage { get; set; }

    int upgradeCostSpeed { get; set; }

    int sellValue { get; set; } 

}
