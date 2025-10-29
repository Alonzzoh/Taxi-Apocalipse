using UnityEngine;

public class ZombiePoints : MonoBehaviour
{
    public static int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue);
            }

            Destroy(gameObject);
        }

        
    }
}
