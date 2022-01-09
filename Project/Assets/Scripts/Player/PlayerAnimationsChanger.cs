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
    private InputActions input;
    private Animator anim;
    public Animator secondAnim;
    private bool isAttackTwoEnable;
    private bool isAction;
    private bool isInventory = false;
    private bool isStopped = false;
    private void Awake()
    {
        input = new InputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        isAction = false;
        isAttackTwoEnable = false;
    }
    void Update()
    {
        if (input.UIInput.Inventory.triggered)
        {
            isInventory = !isInventory;
        }
        if (!isStopped)
        {

            RunLegs();

            if (!isAction)
            {
                Run();
                if (!isInventory)
                {
                    Attack();
                    FrontBlock();
                }
            }
        }
    }

    private void RunLegs()
    {
        Vector2 moveInput = input.PlayerActions.Move.ReadValue<Vector2>();
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
        if (input.PlayerActions.Attack.IsPressed())
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
            if (input.PlayerActions.FrontBlock.IsPressed())
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
        Vector2 moveInput = input.PlayerActions.Move.ReadValue<Vector2>();
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

    public void DisableAnimations()
    {
        isStopped = !isStopped;
        secondAnim.SetInteger("State", 0);
        anim.SetInteger("State", 0);
    }

    public void EnableAnimations()
    {
        isStopped = !isStopped;
    }
}
