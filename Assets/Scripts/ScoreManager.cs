using System.Collections;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    public bool isDoubleScoreActive = false;

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
            ScoreItem1();

            StartCoroutine(ResetScoreMultiplierAfterDelay());
        }
    }

    IEnumerator ResetScoreMultiplierAfterDelay()
    {
        yield return new WaitForSeconds(20f);
        isDoubleScoreActive = false;
    }

    private void ScoreItem1()
    {
        if (isDoubleScoreActive)
        {
            AddScore(2);
        }
        else
        {
            AddScore(1);
        }
    }
}
