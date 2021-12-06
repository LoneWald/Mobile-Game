using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLegsAnimationController : MonoBehaviour
{
    private const string RUN = "Run";

    Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool(RUN, true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _animator.SetBool(RUN, false);
        }
    }
}
