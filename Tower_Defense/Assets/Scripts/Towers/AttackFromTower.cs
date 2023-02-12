using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackFromTower : MonoBehaviour
{
    int enemyNumber = 0;

    bool isAttacking = false;

    List<GameObject> targets = new List<GameObject>();
    [SerializeField] Tower tower;

    public Coroutine attackCoroutine;
    private void OnValidate()
    {
        tower = this.transform.parent.GetComponent<Tower>();
    }

    private UnityAction EnemyDies(Enemy enemy)
    {
        Debug.Log("StopedCoroutine");
        targets.Remove(enemy.gameObject);
        if(attackCoroutine != null)
        tower.StopCoroutine(attackCoroutine);

        if (targets.Count != 0)
        {
            attackCoroutine = tower.StartCoroutine(tower.Attack(targets[0].gameObject));
        }
        else
        {
            isAttacking = false;
        }

        Observer.onEnemyDeathEvent.AddListener(EnemyDies(enemy));

        return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("Enemy in range");
            enemyNumber++;
            targets.Add(other.gameObject);
            if (!isAttacking)
            {
                Observer.onEnemyDeathEvent.AddListener(EnemyDies(other.gameObject.GetComponent<Enemy>()));
                attackCoroutine = tower.StartCoroutine(tower.Attack(targets[0].gameObject));
                Debug.Log("Attack enemy 1");
                isAttacking = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Observer.onEnemyDeathEvent.RemoveListener(EnemyDies(other.gameObject.GetComponent<Enemy>()));
        enemyNumber--;
        if(attackCoroutine != null)
        tower.StopCoroutine(attackCoroutine);
        //StopCoroutine(tower.Attack(targets[0].gameObject));
        targets.Remove(other.gameObject);
        if(targets.Count != 0)
        {
            attackCoroutine = tower.StartCoroutine(tower.Attack(targets[0].gameObject));
        }
        else
        {
            isAttacking = false;
        }
    }

    public void AttackNext()
    {
        Debug.Log("Attacking Next");
        /*enemyNumber--;
        StartCoroutine(tower.Attack(targets[0].gameObject));*/
    }

}
