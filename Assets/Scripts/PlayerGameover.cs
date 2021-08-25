using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameover : MonoBehaviour
{
    Material playerMaterial;
    float count=0;
    float speed= 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        playerMaterial=GetComponent<Renderer>().material;
         playerMaterial.SetFloat("_Dissolve",0);
        count=0;
    }

    // Update is called once per frame
    void Update()
    {

        if(PlayerManager.gameOver){
            if(count<1){
                count+=Time.deltaTime*speed;
                playerMaterial.SetFloat("_Dissolve",count);
            }
           
        }
    }
}
