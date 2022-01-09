using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private Vector2 _direction = new Vector2(1, 0);
    [SerializeField]
    private int _damage = 1;
    [SerializeField]
    private float _speed = 2f;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        MovementLogic(_direction, _speed);
    }

    private void MovementLogic(Vector2 direction, float speed)
    {
        _rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject obj = other.gameObject;
        Debug.Log(obj.name);
        if(obj.tag == "Player"){
            obj.GetComponent<PlayerController>().ChangeHealth(-_damage);
        }
        else if(obj.tag == "Enemy"){
            obj.GetComponent<Enemy>().ChangeHealth(-_damage);
        }
        Destroy(this.gameObject);
    }

    public void setParams(Vector2 direction, float speed, int damage = 1){
        _direction = direction;
        _speed = speed;
        _damage = damage;
    }
}
