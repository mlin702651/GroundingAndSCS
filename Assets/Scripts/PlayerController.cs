using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // speed settings
    public float moveSpeed = 3;
    public float rotationSpeed = 100.0f;

    // get game objects
    public GameObject Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        // if gameStart = false, don't start
        if (!PlayerManager.gameStart) return;

        // move
        Cam.transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);

        
        // rotation float
        float rotationLR = 0;
        float rotationUD = 0;

        // Keycode settings
        if (Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow))
            rotationLR = Input.GetAxis("Horizontal") * rotationSpeed * (-1);
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            rotationUD = Input.GetAxis("Vertical") * rotationSpeed;

        // rotatoin
        rotationLR *= Time.deltaTime;
        rotationUD *= Time.deltaTime;
        
        transform.Rotate(rotationUD, rotationLR, 0, Space.World);
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "wall")
        {
            PlayerManager.gameOver = true;
        }
    }

}
