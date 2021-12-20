using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private int health = 100;
    [SerializeField] private float startTimeBtwAttack = 0.5f;
    [SerializeField] private GameObject currentWeapon;
    private Camera cam;
    private float timeBtwAttack;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    private CharacterActions playerInput;
    private float moveAngle;
    private Animator anim;
    private Vector3 mousePos;
    private AudioSource sworsAudio;
    
    private void Awake()
    {
        playerInput = new CharacterActions();
    }
    private void Start()
    {
        cam = Camera.main;
        timeBtwAttack = startTimeBtwAttack;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sworsAudio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    private void Update()
    {
        if (health <= 0)
            Dead();

        //------ Движение ------//
        Vector2 moveInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        moveVelocity = moveInput.normalized * speed;    // Вектор движения

        /*if (playerInput.PlayerActions.Move.triggered)   // Направление
            moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0), new Vector3(moveVelocity.x, moveVelocity.y, 0), Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));*/
        
        Vector3 mousePosWorld = cam.ScreenToWorldPoint(Input.mousePosition);    // Поворот
        mousePos = new Vector3(mousePosWorld.x, mousePosWorld.y, 0);
        
        moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0), 
                    (mousePos - new Vector3(rb.position.x, rb.position.y, 0)).normalized, 
                    Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));

        // if (moveInput != Vector2.zero)                  // Анимация движения
        //     anim.SetBool("isRunning", true);
        // else
        //     anim.SetBool("isRunning", false);

        //------ Атака -------//
        // if (timeBtwAttack <= 0)         // Перезарядка атаки
        // {
        //     if (playerInput.PlayerActions.Attack.IsPressed())
        //     {
        //         anim.SetTrigger("Attack_2");
        //         timeBtwAttack = startTimeBtwAttack;
        //     }
        // }
        // else
        //     timeBtwAttack -= Time.deltaTime;

    }
    private void FixedUpdate()
    {
        if((new Vector2(mousePos.x, mousePos.y) - rb.position).magnitude > 0.1f){
            rb.MoveRotation(moveAngle);
        }
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        
    }

    public void ChangeHealth(int value)
    {
        health += value;
    }

    //---- Выставляется в конце анимации
    public void DoActtack()
    {
        currentWeapon.GetComponent<PlayerWeapon>().Attack();
    }
    public void PlayAudio(){
        sworsAudio.Play();
    }
    public void Dead()
    {
        //this.transform.Find("DeadModel").gameObject.SetActive(true);
        for(int i = 0; i < this.transform.childCount; i++){
            GameObject child = this.transform.GetChild(i).gameObject;
            child.SetActive(!child.activeSelf);
        }
        rb.simulated = false;
        this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<PlayerAnimationsChanger>().enabled = false;
        sworsAudio.enabled = false;
        anim.enabled = false;
        this.enabled = false;
    }

}
