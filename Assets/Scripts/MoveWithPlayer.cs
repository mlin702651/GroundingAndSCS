using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlayer : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // if gameStart = false, don't start
        if (!PlayerManager.gameStart) return;

        moveSpeed = PlayerController.moveSpeed;
        transform.Translate(0, 0, moveSpeed * Time.deltaTime, Space.World);
    }
}
