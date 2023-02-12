using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyStats stats;

    public float health;
    float speed;

    public int goldDrop;

    public NavMeshAgent agent;
    private void OnEnable()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = stats.speed;
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.sharedMaterial.color = stats.enemyColor;

        health = stats.health;
        speed = stats.speed;
        goldDrop = stats.gold;

        Observer.onEnemyDeathEvent.AddListener(Death());

        //Debug.Log(health);
    }

    private void OnDisable()
    {
        Observer.onEnemyDeathEvent.RemoveListener(Death());
    }
    public void TakeDamage(float damage)
    {
        //Debug.Log("Health: " + health);
        //Debug.Log("Damage: " + damage);
        health -= damage;
        //Debug.Log(health);
        if(health <= 0)
        {
            Observer.onEnemyDeathEvent?.Invoke();
        }
    }

    private void Update()
    {
        ArrivedAtTarget();
    }
    void ArrivedAtTarget()
    {
        if(agent != null)
        {
            float leftDistance = (this.transform.position - agent.destination).magnitude;
            if (leftDistance < 1)
            {
                this.gameObject.SetActive(false);
                Player.Instance.HP.UpdateHP();
                Debug.Log("Enemy entered castle");
            }
        }
    }
    private UnityAction Death()
    {
        if (health <= 0)
        {
            Player.Instance.Coins.UpdateCoins(goldDrop);
            this.gameObject.SetActive(false);
            Destroy(this.gameObject, 1);
        }
        return null;
    }

}
