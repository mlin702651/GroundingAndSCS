using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVirus : MonoBehaviour
{
    public List<GameObject> virus = new List<GameObject>();
    public int virusMode = 1;
    public bool canChange;

    // Start is called before the first frame update
    void Start()
    {
        virusMode = 1;
        canChange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.gameStart) return;


        if(PlayerManager.score % 6 == 0 && canChange)
        {
            virus[virusMode].SetActive(false);
            virusMode = TileManager.hardMode;
            virus[virusMode].SetActive(true);
            canChange = false;
        }
        else
        {
            canChange = true;
        }

        
        

    }
}
