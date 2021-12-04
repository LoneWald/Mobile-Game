using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask enemyLayer;

    public void Attack() // атакует врагов в радиусе круга attackPos
    {
        //---- For player
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().ChangeHealth(-damage);
        }

    }

    // Для наглядности
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
