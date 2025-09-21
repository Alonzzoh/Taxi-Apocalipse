using UnityEngine;

public class Movement : MonoBehaviour
{
    public float acceleration = 10f;  
    public float deceleration = 5f;    
    public float maxSpeed = 20f;      
    public float turnSpeed = 50f;      

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
        else
        {

            currentSpeed -= deceleration * Time.deltaTime;
        }


        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);


        Vector3 forwardMove = transform.forward * currentSpeed;
        rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);

        float turnInput = Input.GetAxis("Horizontal"); 
        if (currentSpeed > 0.1f) 
        {
            transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
        }
    }
}
