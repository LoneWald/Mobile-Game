using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class PlayerAnimationsChanger : MonoBehaviour
{
    [SerializeField] private float startTimeBtwAttack = 0.5f;
    [SerializeField] private float startTimeBtwBlock = 0.5f;
    private float timeBtwAttack;
    private float timeBtwBlock;
    private CharacterActions playerInput;
    private Animator anim;
    public Animator secondAnim;
    private bool isAttackTwoEnable;
    private bool isAction;
    private void Awake()
    {
        playerInput = new CharacterActions();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        isAction = false;
        isAttackTwoEnable = false;
    }
    void Update()
    {
        RunLegs();

        if (!isAction)
        {
            Run();
            Attack();
            FrontBlock();
        }
    }

    private void RunLegs()
    {
        Vector2 moveInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            secondAnim.SetInteger("State", 1);
        }
        else
        {
            secondAnim.SetInteger("State", 0);
        }
    }
    private void Attack()
    {
        timeBtwAttack -= Time.deltaTime;
        if (playerInput.PlayerActions.Attack.IsPressed())
        {
            if (timeBtwAttack <= 0)
            {
                FirstAttack();
            }
            else
            {
                if (isAttackTwoEnable)
                {
                    SecondAttack();
                }
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

    private void FirstAttack()
    {
        anim.SetInteger("State", 2);
        timeBtwAttack = startTimeBtwAttack;
        isAction = true;
        isAttackTwoEnable = true;
    }

    private void SecondAttack()
    {
        anim.SetInteger("State", 8);
        isAction = true;
        isAttackTwoEnable = false;
        timeBtwAttack += startTimeBtwAttack;
    }

    private void FrontBlock()
    {
        if (timeBtwBlock <= 0)
        {
            if (playerInput.PlayerActions.FrontBlock.IsPressed())
            {
                isAction = true;
                anim.SetInteger("State", 4);
                timeBtwBlock = startTimeBtwBlock;
            }
        }
        else
            timeBtwBlock -= Time.deltaTime;
    }

    private void Run()
    {
        Vector2 moveInput = playerInput.PlayerActions.Move.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            anim.SetInteger("State", 1);
        }
        else
        {
            anim.SetInteger("State", 0);
        }
    }
    public void EndAction()
    {
        isAction = false;
    }
}
