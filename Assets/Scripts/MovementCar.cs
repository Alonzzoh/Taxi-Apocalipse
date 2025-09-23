using UnityEngine;

public class MovementCar : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 8f;
    [SerializeField] private float maxSpeed = 15f;       
    [SerializeField] private float laneSpeed = 8f;
    [SerializeField] private float laneDistance = 3f; 

    private float currentSpeed = 0f;
    private int targetLane = 0; 

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);


        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

    
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetLane = Mathf.Max(-1, targetLane - 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            targetLane = Mathf.Min(1, targetLane + 1);
        }


        float targetX = targetLane * laneDistance;
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * laneSpeed);
        transform.position = newPos;
    }
}
