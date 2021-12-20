using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private int damage = 50;
    [SerializeField] private float attackRange;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask playerLayer;

    public void Attack() // атакует врагов в радиусе круга attackPos
    {
        //---- For player
        Collider2D[] player = Physics2D.OverlapCircleAll(attackPos.position, attackRange, playerLayer);
        for (int i = 0; i < player.Length; i++)
        {
            player[i].GetComponent<PlayerController>().ChangeHealth(-damage);
        }

    }
    

    // Для наглядности
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }



}
