using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Assign your TextMeshProUGUI component here
    private int score;
    private bool gameIsActive = true;

    void Update()
    {
        if (gameIsActive)
        {
            // Increment score based on time or another scoring logic
            score = (int)(Time.timeSinceLevelLoad);
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void StopScore()
    {
        gameIsActive = false;
    }
}
