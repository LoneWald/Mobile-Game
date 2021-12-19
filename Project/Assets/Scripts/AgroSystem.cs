using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroSystem : MonoBehaviour
{
    public float maxDistance = 5f;
    public float viewAngle = 30;
    private RaycastHit[] hits;
    public Transform target;
    private Enemy enemyScript;
     public LayerMask mask;
     private float moveAngle;
    void Start()
    {
        enemyScript = gameObject.GetComponent<Enemy>();
    }
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.position - transform.position, (target.position - transform.position).magnitude - 0.3f, mask);
        Vector2 vectorBetween = target.position - transform.position;
        if (Vector2.Angle(transform.TransformDirection(Vector2.up), vectorBetween) < viewAngle && vectorBetween.magnitude < maxDistance)
        {
            if(hit.collider == null){
                enemyScript.SetAgro(true);
            }
            Debug.DrawRay(transform.position, target.position - transform.position, Color.green);
        }

        // Debug.Log(Vector2.Angle(transform.TransformDirection(new Vector2(0f, 1f)), vectorBetween));
        // Debug.DrawRay(transform.position, new Vector2(0f, 1f) * 5f, Color.red);
        // Debug.Log(hit.collider.name);
    }
}
