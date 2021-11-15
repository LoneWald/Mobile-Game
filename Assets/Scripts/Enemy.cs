using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private const int MAX_HEALTH = 100;
    [SerializeField] private int health;

    void Update()
    {
        if(health <= 0)
            GameObject.Destroy(gameObject);
    }

    public void ChangeHealth(int value)
    {
        health += value;
    }
}
