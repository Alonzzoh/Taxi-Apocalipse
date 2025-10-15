using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TargetEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    public float speedChase;
    public bool chase;
    public float range;
    public float distance;

    public Transform player;

    void Update()
    {
        distance = Vector3.Distance(enemy.transform.position, player.position);

        if (distance < range)
        {
            chase = true;
        }
        else if(distance > range)
        {
            chase = false;
        }

        if(chase == false)
        {
            enemy.speed = 0;
            GetComponent<ZombieMovementAI>().enabled = true;
        }
        else if (chase == true)
        {
            enemy.speed = speedChase;
            enemy.SetDestination(player.position);
            GetComponent<ZombieMovementAI>().enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
