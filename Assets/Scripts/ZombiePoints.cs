using UnityEngine;

public class ZombiePoints : MonoBehaviour
{
    public int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager scoreManager = FindFirstObjectByType<ScoreManager>();
            if (scoreManager != null)
            {
                if(ScoreManager.isDoubleScoreActive)
                {
                    scoreManager.AddScore(scoreValue * 2);
                }
                else
                {
                    scoreManager.AddScore(scoreValue);
                }
                    
            }

            Destroy(gameObject);
        }

        
    }
}
