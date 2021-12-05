using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class PlayerAnimationController : MonoBehaviour
{
    private const string STATE = "State";
    private const int Default = 0;
    private const int Run = 1;
    private const int Attack_One = 2;
    private const int Block_Back = 3;
    private const int Block_Front = 4;
    private const int Dash = 5;
    private const int Killed_Back = 6;
    private const int Killed_Front = 7;

    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetInteger(STATE, Run);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetInteger(STATE, Default);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _animator.SetInteger(STATE, Dash);
        }
    }
}
