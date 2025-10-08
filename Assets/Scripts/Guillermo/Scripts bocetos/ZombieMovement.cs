using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{

    public float movSpeed;
    public float rotSpeed;
    public float reacTime;
    [SerializeField]
    private int movement;

    bool wait;
    bool walk;
    bool rotate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        action();
    }

    // Update is called once per frame
    private void Update()
    {
        if(walk)
        {
            transform.position += (transform.forward * movSpeed * Time.deltaTime);
        }
        if(rotate)
        {
            transform.Rotate(Vector3.up * rotSpeed * Time.deltaTime);
        }
        if (wait)
        {

        }
    }

    void action()
    {
        movement = Random.Range(1, 4);

        if(movement == 1)
        {
            walk = true;
            wait = false;
        }
        if (movement == 2)
        {
            wait = true;
            walk = false;
        }
        if (movement == 3)
        {
            rotate = true;
            StartCoroutine(rotateTime());
        }

        Invoke("action", reacTime);
    }

    IEnumerator rotateTime()
    {
        yield return new WaitForSeconds(2);
        rotate = false;
    }
}
