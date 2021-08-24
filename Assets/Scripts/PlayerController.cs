using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // speed settings
    public static float moveSpeed = 10;
    public float rotationSpeed = 200f;
    public float currentRotationSpeed;


    // angles
    public Vector3 myAngles;
    public Vector3 rotateAngles;

    // Start is called before the first frame update
    void Start()
    {
        //Cam = GameObject.Find("Main Camera");

    }

    // Update is called once per frame
    void Update()
    {
        // if gameStart = false, don't start
        if (!PlayerManager.gameStart) return;

        // move
        transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);

        
        // rotation float
        float rotationLR = 0;
        float rotationUD = 0;

        // Keycode settings for rotation
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            currentRotationSpeed = rotationSpeed;
            rotationLR = Input.GetAxis("Horizontal") * currentRotationSpeed * (-1) * Time.deltaTime;
            rotationUD = Input.GetAxis("Vertical") * currentRotationSpeed * Time.deltaTime;
            transform.Rotate(rotationUD, rotationLR, 0, Space.World);
        }
        else
        {
            SmoothRoatation(currentRotationSpeed);
        }
        
       


    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            PlayerManager.gameOver = true;
            Debug.Log("hit wall!");
        }
    }

    void SmoothRoatation(float currentRotationSpeed)
    {
        //if (currentRotationSpeed > 0) currentRotationSpeed -= rotationSpeed /60;
        if (currentRotationSpeed > 0) currentRotationSpeed -= Time.time;
        //if (currentRotationSpeed > 0) currentRotationSpeed = currentRotationSpeed*2/3;
        if (currentRotationSpeed < 20) currentRotationSpeed = 0;
    }
}
