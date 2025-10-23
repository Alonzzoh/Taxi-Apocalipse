using TMPro;
using UnityEngine;

public class Chronometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chronometerText;
    public float time;
    public bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = true;

    }

    private void GameTime()
    {

        if (gameOver != false)
        {
            time -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000);
            chronometerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }


        if (time <= 0)
        {
            chronometerText.text = string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            gameOver = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        GameTime();
    }
}
