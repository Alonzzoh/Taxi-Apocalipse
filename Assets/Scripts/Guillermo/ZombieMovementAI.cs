using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovementAI : MonoBehaviour
{
    public NavMeshAgent AI;
    public float speed;
    public Transform[] objectives;
    Transform objective;
    public float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objective = objectives[Random.Range(0, objectives.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, objective.position);

        if(distance < 2)
        {
            objective = objectives[Random.Range(0, objectives.Length)];
        }

        AI.destination = objective.position;
        AI.speed = speed;
    }
}
