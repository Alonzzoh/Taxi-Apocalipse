using UnityEngine;

public class TaxiPassenger : MonoBehaviour
{

    public GameObject passenger;
    public Transform dropOffPoint;
    private bool hasPassenger = false;
    private bool hasBeenDroppedOff = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == passenger && !hasPassenger && !hasBeenDroppedOff)
        {
            hasPassenger = true;
            passenger.SetActive(false);
        }

        if (other.CompareTag("Drop") && hasPassenger)
        {
            hasPassenger = false;
            hasBeenDroppedOff = true;
            passenger.transform.position = dropOffPoint.position;
            passenger.SetActive(true);
        }
    }
}
