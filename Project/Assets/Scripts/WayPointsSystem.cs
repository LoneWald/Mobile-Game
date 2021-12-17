using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointsSystem : MonoBehaviour
{
    public GameObject[] WayPoints;
    public int num = 0;
    public float speed;
    public float minDist;
    public bool rand = false;
    public bool go = true;
    private Rigidbody2D rb;
    private float moveAngle;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float dist = Vector2.Distance(gameObject.transform.position, WayPoints[num].transform.position);

        if (go)
        {
            if (dist < minDist)
            {
                
                if (!rand)
                {
                    if (num + 1 == WayPoints.Length)
                    {
                        num = 0;
                    }
                    else
                    {
                        num++;
                    }
                }
                else
                {
                    num = Random.Range(0, WayPoints.Length);
                }
            }
        }
    }

    public GameObject GetWayPoint(){
        return WayPoints[num];
    }
}

