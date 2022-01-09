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
    private InputActions input;
    private float moveAngle;
    private Animator anim;
    private Vector3 mousePos;
    private AudioSource sworsAudio;
    public GameObject UI;
    public Inventory inventory;
    public LayerMask itemLayer;
    [SerializeField]
    private bool isStopped = false;
    private GameObject inventoryUI;
    public GameObject retryUI;
    public GameObject[] DeadSprite;

    private void Awake()
    {
        input = new InputActions();
    }
    private void Start()
    {
        retryUI.SetActive(false);
        cam = Camera.main;
        timeBtwAttack = startTimeBtwAttack;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sworsAudio = GetComponent<AudioSource>();
        for(int i = 0; i < UI.transform.childCount; i++){
            if(UI.transform.GetChild(i).name == "Inventory"){
                inventoryUI = UI.transform.GetChild(i).gameObject;
                break;
            }
        }
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    private void Update()
    {
        if (health <= 0)
            Dead();

        if (!isStopped)
        {
            //------ Движение ------//
            Vector2 moveInput = input.PlayerActions.Move.ReadValue<Vector2>();
            moveVelocity = moveInput.normalized * speed;    // Вектор движения

            Vector3 mousePosWorld = cam.ScreenToWorldPoint(Input.mousePosition);    // Поворот
            mousePos = new Vector3(mousePosWorld.x, mousePosWorld.y, 0);

            moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0),
                        (mousePos - new Vector3(rb.position.x, rb.position.y, 0)).normalized,
                        Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
            //------ Движение ------//
            if (input.PlayerActions.TakeItem.triggered)
            {
                TakeItem();
            }
        }


    }
    private void FixedUpdate()
    {
        if (!inventoryUI.activeSelf && !isStopped)
        {
            if ((new Vector2(mousePos.x, mousePos.y) - rb.position).magnitude > 0.1f)
            {
                rb.MoveRotation(moveAngle);
            }
            rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        }
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
    public void PlayAudio()
    {
        sworsAudio.Play();
    }
    public void Dead()
    {
        // for (int i = 0; i < this.transform.childCount; i++)
        // {
        //     GameObject child = this.transform.GetChild(i).gameObject;
        //     child.SetActive(!child.activeSelf);
        // }
        // rb.simulated = false;
        // this.GetComponent<CapsuleCollider2D>().enabled = false;
        // this.GetComponent<SpriteRenderer>().enabled = false;
        // this.GetComponent<PlayerAnimationsChanger>().enabled = false;
        // sworsAudio.enabled = false;
        // anim.enabled = false;
        // retryUI.SetActive(true);
        // this.enabled = false;
        int index = Random.Range(0, DeadSprite.Length);
        Instantiate(DeadSprite[index], transform.position, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, 1));
        retryUI.SetActive(true);
        Destroy(this.gameObject);
    }
    public void TakeItem()
    {
        Collider2D[] items = Physics2D.OverlapCircleAll(transform.position, 0.3f, itemLayer);
        if (items.Length > 0)
            inventory.AddItem(items[0].gameObject.GetComponent<Item>());
    }

    public void DisableControl()
    {
        isStopped = true;
    }

    public void EnableControl()
    {
        isStopped = false;
    }
}
