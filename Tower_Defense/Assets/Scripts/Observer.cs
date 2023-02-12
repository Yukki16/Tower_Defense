using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class Observer 
{
    public static UnityEvent onEnemyDeathEvent = new UnityEvent();

    public delegate void OnPlayerDeath();
    public static OnPlayerDeath onPlayerDeath;

}
