using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

    public GUIText scoreText;
    private int actualScore;
	// Use this for initialization
	void Start () {
        actualScore = 0;
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
}
