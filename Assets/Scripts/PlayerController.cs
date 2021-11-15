using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private int health = 100;
    [SerializeField] private int damage = 50;
    [SerializeField] private float startTimeBtwAttack = 0.5f;
    [SerializeField] private GameObject currentWeapon;
    private Camera cam;
    private float timeBtwAttack;
    private Vector2 moveVelocity;
    private Rigidbody2D rb;
    private CharacterActions playerInput;
    private float moveAngle;
    private Animator anim;
    
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
        //------ Движение ------//
        Vector2 moveInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        moveVelocity = moveInput.normalized * speed;    // Вектор движения
        Vector3 mousePosWorld = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos = new Vector3(mousePosWorld.x, mousePosWorld.y, 0);
        /*if (playerInput.PlayerActions.Move.triggered)   // Направление
            moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0), new Vector3(moveVelocity.x, moveVelocity.y, 0), Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));*/
        moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0), 
                    (mousePos - new Vector3(rb.position.x, rb.position.y, 0)).normalized, 
                    Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
                    Debug.Log((mousePos - new Vector3(rb.position.x, rb.position.y, 0)).normalized);
        if (moveInput != Vector2.zero)                  // Анимация движения
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        //------ Атака -------//
        if (timeBtwAttack <= 0)         // Перезарядка атаки
        {
            if (playerInput.PlayerActions.Attack.IsPressed())
            {
                anim.SetTrigger("Attack_2");
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
            timeBtwAttack -= Time.deltaTime;

    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        rb.MoveRotation(moveAngle);
    }

    public void ChangeHealth(int value)
    {
        health += value;
    }

    public void DoActtack()
    {
        currentWeapon.GetComponent<Weapon>().Attack();
    }



















    /*
    private Player playerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;


    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }


    void Update()
    {

        Vector2 movementInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, movementInput.y, 0);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.up = move;
        }

        // Changes the height position of the player..
        if (playerInput.PlayerActions.JumpForward.triggered)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

*/
}
