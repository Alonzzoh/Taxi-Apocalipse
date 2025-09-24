using UnityEngine;

public class MovementCar : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 5f;
    [SerializeField] private float reverseAcceleration = 6f; 
    [SerializeField] private float maxSpeed = 20f; 
    [SerializeField] private float maxReverseSpeed = 8f; 
    [SerializeField] private float turnSpeed = 50f;    

    private Rigidbody rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currentSpeed -= reverseAcceleration * Time.deltaTime;
        }
        else
        {
            if (currentSpeed > 0)
                currentSpeed -= deceleration * Time.deltaTime;
            else if (currentSpeed < 0)
                currentSpeed += deceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, -maxReverseSpeed, maxSpeed);

        Vector3 forwardMove = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);

        float turnInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
        }
    }
}

