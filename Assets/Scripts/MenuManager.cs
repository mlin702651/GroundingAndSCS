using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
   
    public GameObject menuUI;

    // Start is called before the first frame update
    void Start()
    {
        menuUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        menuUI.SetActive(true);
    }

    public void Stage1()
    {
        SceneManager.LoadScene(1);
    }

    public void Stage2()
    {
        SceneManager.LoadScene(2);
    }

    public void Stage3()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
