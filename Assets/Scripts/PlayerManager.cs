using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Bools of Game Start & Over
    public static bool gameStart, gameOver, finish;

    // Score
    public static int score;

    // Panel for Pause, GameOver
    public GameObject gameStartPanel, gameOverPanel, pausePanel;


    // Start is called before the first frame update
    void Start()
    {
        // reset the settings
        Time.timeScale = 1;
        score = 0;
        gameOverPanel.SetActive(false);
        gameOver = false;
        gameStart = false;
        gameStartPanel.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        // Press W, S, left, right to start
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) &&
            Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            //Time.timeScale = 1;
            gameStart = true;
            gameStartPanel.SetActive(false);
            Debug.Log("start!");
        }

        /*
        // game over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
        */

        // finish
        if (finish)
        {
            
        }
        
    }
    

}
