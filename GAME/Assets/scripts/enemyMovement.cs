using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(enemy))]

public class enemyMovement : MonoBehaviour
{
    private Transform target;
    private int WaypointIndex = 0;

    private enemy enemy;

    void Start()
    {
        enemy = GetComponent<enemy>();
        target = Waypoints.points[0];
    }
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.startSpeed;
    }
    void GetNextWaypoint()
    {
        if (WaypointIndex >= Waypoints.points.Length - 1)
        {
            endPath();
            return;
        }
        WaypointIndex++;
        target = Waypoints.points[WaypointIndex];
    }
    void endPath()
    {
        playerStats.lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }



}
