using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    private const int MAX_HEALTH = 100;
    public Transform target;
    private NavMeshAgent agent;
    [SerializeField] private int health;
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if(health <= 0)
            GameObject.Destroy(gameObject);

        agent.SetDestination(target.position);

        
    }

    public void ChangeHealth(int value)
    {
        health += value;
    }
}
