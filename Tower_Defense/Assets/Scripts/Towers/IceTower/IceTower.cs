using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IceTower : Tower
{
    AttackFromTower attackCollider;
    private void Start()
    {
        attackCollider = GetComponentInChildren<AttackFromTower>();
        damage = stats.damage;
        attackSpeed = stats.attackSpeed;
    }
    public override IEnumerator Attack(List<GameObject> enemy)
    {
        if (enemy.Count == 0)
        {
            yield break;
        }
        //Debug.Log(enemy.gameObject.name);
        yield return new WaitForSeconds(attackSpeed / 10.0f);
        if (enemy != null)
        {
            foreach (GameObject e in enemy)
            {
                NavMeshAgent agent = e.GetComponent<NavMeshAgent>();
                if (agent.speed >= damage)
                    agent.speed = damage;
            }
            attackCollider.attackCoroutine = StartCoroutine(Attack(enemy));
        }
    }
}
