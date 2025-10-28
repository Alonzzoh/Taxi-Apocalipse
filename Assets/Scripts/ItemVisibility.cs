using UnityEngine;

public class ItemVisibility : MonoBehaviour
{
    private float respawnTime = 20.0f; // tiempo de respawn 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("Reappear", respawnTime);
            gameObject.SetActive(false);

        }
    }

    void Reappear()
    {

        gameObject.SetActive(true);
    }
}
