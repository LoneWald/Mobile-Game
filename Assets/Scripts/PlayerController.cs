using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 moveVelocity;
    private Rigidbody2D rb;
    private Player playerInput;
    private float moveAngle;
    private void Awake()
    {
        playerInput = new Player();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 moveInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        moveVelocity = moveInput.normalized * speed;
        if (playerInput.PlayerActions.Move.triggered)
            moveAngle = Vector3.SignedAngle(new Vector3(0, 1, 0), new Vector3(moveVelocity.x, moveVelocity.y, 0), Vector3.Cross(new Vector3(1, 0, 0), new Vector3(0, 1, 0)));
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        rb.MoveRotation(moveAngle);
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
