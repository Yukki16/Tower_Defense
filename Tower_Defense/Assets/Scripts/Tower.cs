using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour, IPlaceable
{
    int cost;
    int level;

    void IPlaceable.Upgrade()
    {
        level++;
    }

    void IPlaceable.Sell()
    {

    }
}
