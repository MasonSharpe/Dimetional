using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyChase : MonoBehaviour
{
    public Transform target;
    public float speed = 2000f;
    public float nextWaypointDistance = 3f;
    public float chaseDistance = 5f;
    Path path;
    bool spotted = false;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody rb;
    SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spriteR = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        InvokeRepeating("UpdatePath", 0, 0.5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            Vector3 dist = rb.position - target.position;
            if (Mathf.Abs(dist.x) + Mathf.Abs(dist.y) < chaseDistance || spotted)
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
                spotted = true;
            }
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        ChaseTarget();
    }

    void ChaseTarget()
    {
        Vector3 direction = path.vectorPath[currentWaypoint] - rb.position;
        if(direction.magnitude < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        direction.Normalize();
        Vector3 velocity = direction * speed * Time.deltaTime;
        rb.velocity = velocity;
    }
}
