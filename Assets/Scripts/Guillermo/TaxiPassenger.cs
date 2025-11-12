using UnityEngine;
using TMPro;

public class TaxiPassenger : MonoBehaviour
{

    public GameObject passenger;
    public Transform dropOffPoint;
    public TextMeshProUGUI actionText;
    private bool hasPassenger = false;
    private bool hasBeenDroppedOff = false;

    void Start()
    {
        if (actionText != null)
            actionText.gameObject.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == passenger && !hasPassenger && !hasBeenDroppedOff)
        {
            actionText.gameObject.SetActive(true);
            actionText.text = "Presiona E para recoger al pasajero";

            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPassenger = true;
                passenger.SetActive(false);
                actionText.gameObject.SetActive(false);
                Debug.Log("Pasajero recogido");
            }
        }

        else if (other.CompareTag("Drop") && hasPassenger)
        {
            actionText.gameObject.SetActive(true);
            actionText.text = "Presiona E para dejar al pasajero";

            if (Input.GetKeyDown(KeyCode.E))
            {
                hasPassenger = false;
                hasBeenDroppedOff = true;
                Vector3 spawnPos = dropOffPoint.position + Vector3.up * 2f;
                if (Physics.Raycast(spawnPos, Vector3.down, out RaycastHit hit, 5f))
                {
                    passenger.transform.position = hit.point;
                }
                else
                {
                    passenger.transform.position = dropOffPoint.position + Vector3.up * 1f;
                }
                passenger.SetActive(true);
                actionText.gameObject.SetActive(false);
                Debug.Log("Pasajero dejado en destino");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == passenger || other.CompareTag("Drop"))
        {
            if (actionText != null)
                actionText.gameObject.SetActive(false);
        }
    }
}