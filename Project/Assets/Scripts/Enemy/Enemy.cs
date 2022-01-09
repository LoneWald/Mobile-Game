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
    private const int MAX_HEALTH = 1;
    public Transform playerTarget;
    private Transform target;
    private Rigidbody2D rb;
    private NavMeshAgent agent;
    private Animator anim;
    private WayPointsSystem way;
    private WeaponScript weapon;
    public bool isAgro = false;
    private bool isArrived = false;
    private bool isCoroutineProceed = false;
    private bool isGo = true;
    private float moveAngle;
    [SerializeField] private int health;
    public float stayToThink = 2f;
    
    private float minDistPoint = 0.01f;
    public float minDistToPlayer = 2f;
    private void Start()
    {
        anim = GetComponent<Animator>();
        timeBtwAttack = startTimeBtwAttack;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        rb = GetComponent<Rigidbody2D>();
        way = GetComponent<WayPointsSystem>();
        weapon = GetComponentsInChildren<WeaponScript>()[0];
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAgro)
        {
            if (isArrived)
            {
                if (!isCoroutineProceed)
                {
                    StartCoroutine(wait());
                }
            }
            else
            {
                if (way.GetWayPoint() != null)
                    target = way.GetWayPoint().transform;
                else
                    target = null;
            }
        }
        else
        {
            target = playerTarget;
            weapon.Shoot();
            // //---- Attack ----
            // if (timeBtwAttack <= 0)         // Перезарядка атаки
            // {
            //     if ((target.position - new Vector3(rb.position.x, rb.position.y, 0)).magnitude < attaclRadius)
            //     {
            //         anim.SetTrigger("Attack");
            //         timeBtwAttack = startTimeBtwAttack;
            //     }
            // }
            // else
            //     timeBtwAttack -= Time.deltaTime;
        }
        if (target != null)
        {
            if (isGo)
            {
                moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0),
                        (target.position - new Vector3(rb.position.x, rb.position.y, 0)).normalized,
                        Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
            }
            Rotate();
            agent.SetDestination(target.position);
        }

        if (health <= 0)
        {
            Dead();
        }
    }

    private void Rotate()
    {
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
        this.transform.Find("DeadModel").gameObject.SetActive(true);
        //this.transform.Find("EnemyModel").gameObject.SetActive(false);
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.enabled = false;
    }

    public void SetAgro(bool agro)
    {
        isAgro = agro;
    }

    public void SetArrived(bool arrive)
    {
        isArrived = arrive;
    }

    IEnumerator wait()
    {
        isGo = false;
        isCoroutineProceed = true;
        yield return new WaitForSeconds(stayToThink);
        isCoroutineProceed = false;
        isArrived = false;
        isGo = true;
    }
}
