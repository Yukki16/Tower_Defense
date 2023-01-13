using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cost", menuName = "ScriptableObjects/Cost")]
public class Cost : ScriptableObject
{
    public int buyCost = 0;
    public int upgradeCost = 0;
}

[CreateAssetMenu(fileName = "SellValue", menuName = "ScriptableObjects/SellValue")]
public class Sell : ScriptableObject
{
    public int sellPercent = 70;
}
