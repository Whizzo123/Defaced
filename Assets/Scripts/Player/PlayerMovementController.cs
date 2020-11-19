using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    private Rigidbody2D playerBody;
    public CapsuleCollider2D normalCollider;
    public BoxCollider2D crouchCollider;
    public bool isCrouching;
    private PlayerInputController input_Controller;

    public float moveSpeed;
    public float cappedVelocity;
    public float jumpPower;
    public float frictionTimeDivider;
    public float cappedJumpVelocity;
    
    public int jumpCounter;
    public int jumpLimit;
    public bool isJumping;

    private bool onGround;


    void Start()
    {
        
        playerBody = GetComponent<Rigidbody2D>();
        input_Controller = GetComponent<PlayerInputController>();
    }

    public void Move(float horizontalInput)
    {
        
        Vector2 moveVelocity = new Vector2(horizontalInput * (moveSpeed * Time.deltaTime), 0);
        if(Mathf.Abs(playerBody.velocity.x) < cappedVelocity)
        {
            playerBody.velocity += moveVelocity;
        }
    }

    void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < input_Controller.HorizontalThreshold)
        {
            if (Mathf.Abs(playerBody.velocity.x) > .1f)
            {
                float friction = Mathf.Lerp(playerBody.velocity.x, 0, Time.deltaTime / frictionTimeDivider);
                playerBody.velocity = new Vector2(friction, playerBody.velocity.y);
            }
            else
            {
                playerBody.velocity = new Vector2(0, playerBody.velocity.y);
            }
        }
    }

    public void Jump()
    {
        if (jumpCounter < jumpLimit)
        {
            isJumping = true;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            playerBody.velocity += jumpVelocity;
            if (Mathf.Abs(playerBody.velocity.y) > cappedJumpVelocity)
            {
                Debug.Log("Exceeding jump cap velocity is " + Mathf.Abs(playerBody.velocity.y) + " capped velocity " + cappedJumpVelocity);
                playerBody.velocity = new Vector2(playerBody.velocity.x, cappedJumpVelocity);
            }

            jumpCounter++;
        }
    }

    public void Crouch(bool toggle)
    {
        if (toggle)
        {
            crouchCollider.enabled = false;
            isCrouching = true;
        }
        else
        {
            crouchCollider.enabled = true;
            isCrouching = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.tag == ("Ground") || (other.gameObject.GetComponent<Pushable>() && other.gameObject.transform.position.y < this.transform.position.y)))
        {
            onGround = true;
            jumpCounter = 0;
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        onGround = false;
    }

}
