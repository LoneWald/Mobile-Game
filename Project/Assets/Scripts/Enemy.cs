using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [SerializeField] private float startTimeBtwAttack = 0.5f;
    [SerializeField] private float attaclRadius = 1f;
    [SerializeField] private GameObject currentWeapon;
    private float timeBtwAttack;
    private const int MAX_HEALTH = 100;
    public Transform playerTarget;
    private Transform target;
    private Rigidbody2D rb;
    private NavMeshAgent agent;
    private Animator anim;
    private WayPointsSystem way;
    public bool isAgro = false;



    private float moveAngle;
    [SerializeField] private int health;
    private void Start()
    {
        anim = GetComponent<Animator>();
        timeBtwAttack = startTimeBtwAttack;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>();
        way = GetComponent<WayPointsSystem>();
    }

    void Update()
    {
        if (!isAgro)
        {
            target = way.GetWayPoint().transform;
        }
        else
        {
            target = playerTarget;

            //---- Attack ----
            if (timeBtwAttack <= 0)         // Перезарядка атаки
            {
                if ((target.position - new Vector3(rb.position.x, rb.position.y, 0)).magnitude < attaclRadius)
                {
                    anim.SetTrigger("Attack");
                    timeBtwAttack = startTimeBtwAttack;
                }
            }
            else
                timeBtwAttack -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Dead();
        }

        agent.SetDestination(target.position);
        rb.AddTorque(10 * Time.deltaTime);

        //---- Rotation ----
        moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0),
                    (target.position - new Vector3(rb.position.x, rb.position.y, 0)).normalized,
                    Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
        transform.localEulerAngles = new Vector3(0, 0, moveAngle);


    }
    public void ChangeHealth(int value)
    {
        health += value;
    }

    //---- Выставляется в конце анимации
    public void DoActtack()
    {
        currentWeapon.GetComponent<EnemyWeapon>().Attack();
    }

    public void Dead()
    {
        this.transform.Find("EnemyModel").gameObject.SetActive(false);
        this.transform.Find("DeadModel").gameObject.SetActive(true);
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.enabled = false;
    }

    public void SetAgro(bool agro){
        isAgro = agro;
    }
}
