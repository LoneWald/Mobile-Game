using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class PlayerAnimationController : MonoBehaviour
{
    private const string RUN = "Run";

    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A)
            || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetBool(RUN, true);
        }
        else
        {
            _animator.SetBool(RUN, false);
        }
    }
}
