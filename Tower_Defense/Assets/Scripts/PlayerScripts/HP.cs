using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HP : MonoBehaviour
{
    public int hp = 1;

    public TMP_Text hpText;

    private void Update()
    {
        if(hp <= 0)
        {
            Observer.onPlayerDeath?.Invoke();
        }
    }
    public void EndGame()
    {
        MonoBehaviour[] a = FindObjectsOfType<MonoBehaviour>();
        for (int i = 0; i < a.Length; i++)
        {
            a[i].StopAllCoroutines();
        }

        Observer.onEnemyDeathEvent.RemoveAllListeners();
        Observer.onPlayerDeath = null;

        Debug.Log("Ended Game!");
    }

    public void UpdateHP()
    {
        hp--;
        hpText.text = "Health: " + hp.ToString();
    }
}
