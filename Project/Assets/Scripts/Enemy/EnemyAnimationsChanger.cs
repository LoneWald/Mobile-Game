using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationsChanger : MonoBehaviour
{
    private Vector2 lastPosition;
    private Vector2 currentPosition;
    private Animator anim;
    public Animator secondAnim;
    private bool isAction;
    void Start()
    {
        lastPosition = Vector2.zero;
        currentPosition = this.transform.position;
        anim = GetComponent<Animator>();
        isAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        RunLegs();

        if (!isAction)
        {
            Run();
        }
    }

    private void LateUpdate() {
        lastPosition = currentPosition;
        currentPosition = this.transform.position;
    }

    private void RunLegs()
    {
        if(lastPosition != currentPosition){
            secondAnim.SetInteger("State", 1);
        }
        else{
            secondAnim.SetInteger("State", 0);
        }
    }

    private void Run()
    {
        if(lastPosition != currentPosition){
            anim.SetInteger("State", 1);
        }
        else{
            anim.SetInteger("State", 0);
        }
    }

    public void Shoot(){
        anim.SetInteger("State", 2);
        isAction = true;
    }

    public void EndAction()
    {
        isAction = false;
    }
}
