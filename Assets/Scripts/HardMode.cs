using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardMode : MonoBehaviour
{
    public static bool hardMode;
    public bool isHard;

    public void click(bool isOn)
    {
        if(isOn)
        {
            hardMode = true;
        }
        else
        {
            hardMode = false;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isHard = hardMode;
    }
}
