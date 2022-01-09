using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class WayPointsSystem : MonoBehaviour
{
    public GameObject[] WayPoints;
    public int num = 0;
    public float speed;
    private float minDist = 0.01f;
    public bool rand = false;
    public bool go = true;
    private Rigidbody2D rb;
    private float moveAngle;
    private Enemy en;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        en = GetComponent<Enemy>();
    }

    void Update()
    {
        if (WayPoints.Length > 0)
        {
            float dist = Vector2.Distance(gameObject.transform.position, WayPoints[num].transform.position);

            if (go)
            {
                if (dist < minDist)
                {
                    en.SetArrived(true);
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
    }

    public GameObject GetWayPoint()
    {
        if (WayPoints.Length > 0)
            return WayPoints[num];
        else
            return null;
    }
}

