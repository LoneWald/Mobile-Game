using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroSystem : MonoBehaviour
{
    private RaycastHit[] hits;
    public Collider2D player;
    private Enemy agroScript;
     public LayerMask mask;
    void Start()
    {
        agroScript = gameObject.GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawRays();
        RaycastHit2D[] hits = {new RaycastHit2D(), new RaycastHit2D(), new RaycastHit2D(), new RaycastHit2D(), new RaycastHit2D(), new RaycastHit2D(), new RaycastHit2D()};
        for (int i = 0; i < 7; i++){
            hits[i] = Physics2D.Raycast(transform.position, transform.TransformDirection(new Vector2((i-3)*0.1f, 1f)), 5f,  mask);
        }
        foreach(RaycastHit2D hit in hits){
            Debug.Log(hit.collider.name);
            if(hit.collider == player){
                agroScript.SetAgro(true);
            }
        }
    }

    public void DrawRays()
{
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(-0.3f, 1f)) * 5f, Color.red);
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(-0.2f, 1f)) * 5f, Color.red);
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(-0.1f, 1f)) * 5f, Color.red);
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(0f, 1f)) * 5f, Color.red);
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(0.1f, 1f)).normalized * 5f, Color.red);
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(0.2f, 1f)).normalized * 5f, Color.red);
    Debug.DrawRay(transform.position, transform.TransformDirection(new Vector2(0.3f, 1f)).normalized * 5f, Color.red);
}
}
