using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] PlayerStats stats;

    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            if(instance == null)
            {
                GameObject go = new GameObject(typeof(Player).Name);
                instance = go.AddComponent<Player>();
                DontDestroyOnLoad(go);
            }

            return instance;
        }
    }

    public Coins Coins { get; private set; }
    public HP HP { get; private set; }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as Player;
            DontDestroyOnLoad(gameObject);
        }

        Coins = GetComponentInChildren<Coins>();
        HP = GetComponentInChildren<HP>();

        Coins.coinsAmmount = stats.startingMoney;
        HP.hp = stats.health;

        Coins.UpdateCoins(0);
        HP.hpText.text = "Health: " + HP.hp.ToString(); 

        Observer.onPlayerDeath += HP.EndGame;
    }

    /*private void OnEnable()
    {
        currentMoney = stats.startingMoney;
        timeBetweenRounds = stats.timeBetweenRounds;
        Observer.onEnemyDeath += AddMoney;
    }

    public static float GetTimeForPreparation()
    {
        return Instance.timeBetweenRounds;
    }
    public void AddMoney(Enemy enemy)
    {
        currentMoney += enemy.goldDrop;
    }*/
}
