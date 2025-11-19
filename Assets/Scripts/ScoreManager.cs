using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;

    public static bool isDoubleScoreActive = false;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = " " + score;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Score2x"))
        {
            isDoubleScoreActive = true;

            Debug.Log("Double Score Activated!");
            StartCoroutine(ResetScoreMultiplierAfterDelay());
        }
    }

    IEnumerator ResetScoreMultiplierAfterDelay()
    {
        yield return new WaitForSeconds(20f);
        isDoubleScoreActive = false;
        Debug.Log("Double Score Deactivated!");
    }
}
