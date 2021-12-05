using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimationTorrler : MonoBehaviour
{
    private const string DEFAULT = "Player_Default_State";
    private const string DEFAULT_LEGS = "Player_Run_Legs_Default";

    private const string RUN_BODY = "Player_Run_Body";
    private const string RUN_LEGS = "Player_Run_Legs";

    private const string ATTACK_ONE = "";
    private const string ATTACK_TWO = "";

    private const string BLOCK_FRONT = "";
    private const string BLOCK_FRONT_SUCCESS = "";
    private const string BLOCK_BACK = "";
    private const string BLOCK_BACK_SUCCESS = "";

    private const string DASH = "";

    private const string KILLED_FRONT = "";
    private const string KILLED_BACK = "";

    private List<Animator> _animators = new List<Animator>();

    void Start()
    {
        _animators.Add(GetComponent<Animator>());
        _animators.AddRange(GetComponentsInChildren<Animator>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayAnimation(DEFAULT, DEFAULT_LEGS);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PlayAnimation(RUN_BODY, RUN_LEGS);
        }
    }

    private void PlayAnimation(params string[] animationNames)
    {
        foreach (var name in animationNames)
        {
            foreach (var animator in _animators)
            {
                animator.Play(name);
            }
        }
    }
}
