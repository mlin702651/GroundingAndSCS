using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadColor : MonoBehaviour
{
    public int changeColor = 6;//通過多少門換一次顏色
    public Material material;
    public Color color01;
    public Color color02;
    public Color color03;
    
    Color currentColor;
    Color nextColor;
    Color lerpedColor;
    int randColor=0;
    int countColor=0;
    bool isChangingColor=false;
    float countTime=0;
    bool countTimeEquleOne=false;
    //
    public int score=0;


    // Start is called before the first frame update
    void Start()
    {
        material.SetColor("_Color", new Color(0,0.37f,0.9f));
        currentColor=color03;
        nextColor=color03;
        //score = PlayerManager.score;

    }

    // Update is called once per frame
    void Update()
    {
        // get score from PlayerManager
        //score = PlayerManager.score;

        if (score % changeColor ==0 && !isChangingColor){
            countColor+=1;
            countColor=countColor%3;
            isChangingColor=true;
            countTime=0;
        }
       
        if(isChangingColor){
            chooseColor(countColor);
            if(score%6!=0){
                isChangingColor=false;
            }
        }
    }

    void chooseColor(int type){
        if(countTime<=1){
            countTime+=Time.deltaTime;
            if(type==0){
            currentColor=color03;
            nextColor=color01;
            }
            else if(type==1){
                currentColor=color01;
                nextColor=color02;
            }
            else{
                currentColor=color02;
                nextColor=color03;
            }
            lerpedColor=Color.Lerp(currentColor,nextColor,countTime);
            material.SetColor("_Color", lerpedColor);
        }
        else{
            countTimeEquleOne=true;
        }
        Debug.Log(type);
        
    }
}
