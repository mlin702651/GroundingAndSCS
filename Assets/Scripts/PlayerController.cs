using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // speed settings
    public float forwardSpeed = 0.5f;
    public static float moveSpeed;
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
        if (!PlayerManager.gameStart) { moveSpeed = 0; }
        else if (PlayerManager.gameOver) { moveSpeed = 0; return; }
        else { moveSpeed = forwardSpeed; }
        
        
       

        // move
        transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);

        
        // rotation float
        float rotationLR = 0;
        float rotationUD = 0;

        
        if(HardMode.hardMode)
        {
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
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 90, 0, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(0, -90, 0, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                transform.Rotate(90, 0, 0, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                transform.Rotate(-90, 0, 0, Space.World);
            }
        }
        
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation =  Quaternion.Euler(0, 0, 0);
        }
        
       


    }

    

    private void OnCollisionEnter(Collision collision)
    {
        /*
        if (collision.transform.tag == "Wall")
        {
            //PlayerManager.gameOver = true;
            //Scene scene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(scene.name);
            Debug.Log("hit wall!");
        }
        */

        PlayerManager.gameOver = true;
        Debug.Log("hit wall!");
    }

    void SmoothRoatation(float currentRotationSpeed)
    {
        //if (currentRotationSpeed > 0) currentRotationSpeed -= rotationSpeed /60;
        if (currentRotationSpeed > 0) currentRotationSpeed -= Time.time;
        //if (currentRotationSpeed > 0) currentRotationSpeed = currentRotationSpeed*2/3;
        if (currentRotationSpeed < 20) currentRotationSpeed = 0;
    }
}
