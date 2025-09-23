using UnityEngine;

public class CameraCar : MonoBehaviour
{
    public Transform target;
    public float distance = 6f;
    public float height = 3f;
    public float sensitivity = 3f;

    private float yaw = 0f;
    private float pitch = 10f;

    void LateUpdate()
    {
        if (target == null) return;


        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -10f, 45f);


        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 position = target.position - (rotation * Vector3.forward * distance) + Vector3.up * height;

        transform.position = position;
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
