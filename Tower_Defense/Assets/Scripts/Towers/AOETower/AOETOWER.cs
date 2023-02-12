using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOETOWER : Tower
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
                Enemy enemyScript = e.GetComponent<Enemy>();
                if (enemyScript != null)
                {
                    enemyScript.TakeDamage(damage);
                }
            }
            attackCollider.attackCoroutine = StartCoroutine(Attack(enemy));
        }
    }
}
