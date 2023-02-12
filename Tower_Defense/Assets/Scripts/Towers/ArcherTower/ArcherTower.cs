using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherTower : Tower
{
    AttackFromTower attackCollider;
    private void Start()
    {
        attackCollider = GetComponentInChildren<AttackFromTower>();
        damage = stats.damage;
        attackSpeed = stats.attackSpeed;
    }
    public override IEnumerator Attack(List<GameObject> enemies)
    {
        if(enemies.Count == 0)
        {
            yield break;
        }
        //Debug.Log(enemy.gameObject.name);
        yield return new WaitForSeconds(attackSpeed / 10.0f);
        if (enemies != null)
        {
            Enemy enemyScript = enemies[0].GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(damage);
            }
            else
            {
                yield break;
            }
            attackCollider.attackCoroutine = StartCoroutine(Attack(enemies));
        }
    }

    /*public void StopAttack(Enemy enemy)
    {
        StopCoroutine(Attack(enemy.gameObject));
    }*/
}
