using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{


    public float HorizontalThreshold;
    private PlayerMovementController mv_controller;

    void Start()
    {
        mv_controller = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) > HorizontalThreshold)
        {
            //Move player
            mv_controller.Move(Input.GetAxisRaw("Horizontal"));
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Player jump
            mv_controller.Jump();
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            mv_controller.Crouch(true);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            mv_controller.Crouch(false);
        }

        if(this.transform.position.y < -20f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
