using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Observer 
{
    public delegate void OnEnemyDeathEvent(Enemy enemy);
    public static OnEnemyDeathEvent onEnemyDeath;

    public delegate void OnCoinChange();
    public static OnCoinChange onCoinChange;

    public delegate void OnPlayerDeath();
    public static OnPlayerDeath onPlayerDeath;

}
