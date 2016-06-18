using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

    public GUIText scoreText;
    public GUIText livesText;
    private int actualScore;
	// Use this for initialization
	void Start () {
        actualScore = 0;
        livesText.text = "Lives: " + 3;
        UpdateScore();
	}

    public void addScore (int score)
    {
        actualScore += score;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + actualScore;
    }

    public void updateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}
