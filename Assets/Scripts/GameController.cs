using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject player;
    public GUIText GameOverText;
    private bool gameOverMode= false;
    void Start()
    {
        
    }

    void Update()
    {
        if(gameOverMode && Input.GetButton("Jump"))
        {
            Application.LoadLevel(0);
        }
    }
   
        

    public void GameOver()
    {
        GameOverText.enabled = true;
        gameOverMode = true;
    }

    
}
