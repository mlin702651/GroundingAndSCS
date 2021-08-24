using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public Text scoreText;
    public GameObject startSceneUI;
    

    //換成主程式的變數
    public int score=0;
    public bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text= "" + score;

        if(isPlaying){
            startSceneUI.SetActive(false);
        }
        else{
            startSceneUI.SetActive(true);
        }

        
    }
}
