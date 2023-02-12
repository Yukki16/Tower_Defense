using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] EnemyStats stats;

    public float health;
    public float speed;

    public int goldDrop;

    public NavMeshAgent agent;

    [SerializeField] GameObject canvasHP;
    [SerializeField] Slider HPSlider;
    private void OnEnable()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.speed = stats.speed;
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.sharedMaterial.color = stats.enemyColor;

        health = stats.health;
        speed = stats.speed;
        goldDrop = stats.gold;

        HPSlider.value = health / stats.health;

        Observer.onEnemyDeath += Death;


        //Debug.Log(health);
    }

    private void OnDisable()
    {
        Observer.onEnemyDeath -= Death;
    }
    public void TakeDamage(float damage)
    {
        //Debug.Log("Health: " + health);
        //Debug.Log("Damage: " + damage);
        health -= damage;
        HPSlider.value = health / stats.health;
        Debug.Log(health);
        if(health <= 0)
        {
            Observer.onEnemyDeath?.Invoke(this);
        }
    }

    private void Update()
    {
        ArrivedAtTarget();
        if(canvasHP != null)
        {
            canvasHP.transform.LookAt(Camera.main.transform);
        }
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
                Destroy(this.gameObject, 1);
            }
        }
    }
    private void Death(Enemy enemy)
    {
        if (health <= 0)
        {
            Player.Instance.Coins.UpdateCoins(goldDrop);
            enemy.gameObject.SetActive(false);
            Destroy(this.gameObject, 1);
        }
        //return null;
    }

}
