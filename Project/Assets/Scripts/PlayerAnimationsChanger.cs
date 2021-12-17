using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsChanger : MonoBehaviour
{
    [SerializeField] private float startTimeBtwAttack = 0.5f;
    private float timeBtwAttack;
    private CharacterActions playerInput;
    private Animator anim;
    public Animator secondAnim;
    private void Awake()
    {
        playerInput = new CharacterActions();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
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
        //----- Move -----//
        Vector2 moveInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            secondAnim.SetInteger("State", 1);
            anim.SetInteger("State", 1);
        }
        else
        {
            secondAnim.SetInteger("State", 0);
            anim.SetInteger("State", 0);
        }

        //----- Attack -----//
        if (timeBtwAttack <= 0)         // Перезарядка атаки
        {
            if (playerInput.PlayerActions.Attack.IsPressed())
            {
                anim.SetInteger("State", 2);
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
            timeBtwAttack -= Time.deltaTime;
    }
}
