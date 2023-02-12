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
    public override IEnumerator Attack(GameObject enemy)
    {
        if(!enemy.activeSelf)
        {
            yield break;
        }
        Debug.Log(enemy.gameObject.name);
        yield return new WaitForSeconds(attackSpeed / 10.0f);
        if (enemy != null)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            enemyScript.TakeDamage(damage);
            attackCollider.attackCoroutine = StartCoroutine(Attack(enemy));
        }
    }

    /*public void StopAttack(Enemy enemy)
    {
        StopCoroutine(Attack(enemy.gameObject));
    }*/
}
