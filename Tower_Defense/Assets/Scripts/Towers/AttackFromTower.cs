using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

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

    private void EnemyDies(Enemy enemy)
    {
        if (enemy.health < 0)
        {
            Debug.Log("StopedCoroutine");
            targets.Remove(enemy.gameObject);
            if (attackCoroutine != null)
                tower.StopCoroutine(attackCoroutine);

            if (targets.Count != 0)
            {
                attackCoroutine = tower.StartCoroutine(tower.Attack(targets));
            }
            else
            {
                isAttacking = false;
            }

            //Observer.onEnemyDeathEvent.RemoveListener(EnemyDies(enemy));
        }

        //return null;
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
                Observer.onEnemyDeath += EnemyDies;
                attackCoroutine = tower.StartCoroutine(tower.Attack(targets));
                //Debug.Log("Attack enemy 1");
                isAttacking = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<NavMeshAgent>().speed = other.gameObject.GetComponent<Enemy>().speed;
        if (other.gameObject.GetComponent<Enemy>() != null)
        {
            //Debug.Log(other.gameObject.TryGetComponent<Enemy>(out Enemy enemy));
            Observer.onEnemyDeath -= EnemyDies;
        }
        enemyNumber--;
        if(attackCoroutine != null)
        tower.StopCoroutine(attackCoroutine);
        //StopCoroutine(tower.Attack(targets[0].gameObject));
        targets.Remove(other.gameObject);
        if(targets.Count != 0)
        {
            attackCoroutine = tower.StartCoroutine(tower.Attack(targets));
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
