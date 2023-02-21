using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFollow : MonoBehaviour
{

    GameObject[] allWP;
    [SerializeField] float speed;
    int i = 0;

    void Start()
    {
        GetAllWayPoints();
    }


    void Update()
    {
        MoveAlongThePath();
    }

    void GetAllWayPoints()
    {
        allWP = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    void MoveAlongThePath()
    {
        if (i < allWP.Length)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, allWP[i].transform.position, step);
            if (transform.position == allWP[i].transform.position)
            {
                i++;
            }
        }
    }
}
