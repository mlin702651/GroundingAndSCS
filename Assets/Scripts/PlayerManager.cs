using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Bools of Game Start & Over
    public static bool gameStart, gameOver;

    // Score
    public static int score;

    // Panel for Pause, GameOver
    public GameObject gameStartPanel, gameOverPanel, pausePanel;


    // Start is called before the first frame update
    void Start()
    {
        // reset the settings
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        gameOver = false;
        gameStart = false;
        gameStartPanel.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) &&
            Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            gameStart = true;
            gameStartPanel.SetActive(false);
        }
    }
    

}
