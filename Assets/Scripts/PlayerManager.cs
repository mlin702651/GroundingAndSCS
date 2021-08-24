using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Bools of Game Start & Over
    public static bool gameStart, gameOver, finish;

    // Score
    //public static int score;

    // Panel for Pause, GameOver
    public GameObject gameStartUI, gameOverUI, pauseUI, gameFibishUI;


    // Start is called before the first frame update
    void Start()
    {
        // reset the settings
        //Time.timeScale = 1;
        //score = 0;

        // show gameStartUI and hide others
        gameStartUI.SetActive(true);
        gameOverUI.SetActive(false);
        pauseUI.SetActive(false);
        gameFibishUI.SetActive(false);
        

        // set gaming bools
        gameOver = false;
        gameStart = false;
        finish = false;
        


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
            gameStartUI.SetActive(false);
            Debug.Log("start!");
        }

        
        // game over
        if (gameOver)
        {
            //Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
        

        // finish
        if (finish)
        {
            gameFibishUI.SetActive(true);
            
        }


        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);

    }

    public void Resume()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    public void Retry()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
       
    }

    public void Next()
    {
        Scene thisScene = SceneManager.GetActiveScene();
        if (thisScene.rootCount < 3)
        {
            SceneManager.LoadScene(thisScene.rootCount + 1);
        }
            
        else
        {
            Debug.Log("finish all!");
        }
            
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
