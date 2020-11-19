using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator { get; private set; }
    private SpriteRenderer spriteRenderer;
    private SwitchMask switchMask;
    private PlayerMovementController playerMovementController;
    float horizontal;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
            Debug.LogError("You've forgotten the animator");
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
            Debug.LogError("You've forgotten the spriterenderer");
        switchMask = FindObjectOfType<SwitchMask>();
        playerMovementController = GetComponent<PlayerMovementController>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (!FindObjectOfType<PlayerInputController>().paused)
        {
            if (horizontal > 0.01f)
            {
                spriteRenderer.flipX = false;
            }
            else if (horizontal < -0.01f)
            {
                spriteRenderer.flipX = true;
            }
        }

        animator.SetFloat("Velocity", Mathf.Abs(horizontal));
        animator.SetBool("isJumping", playerMovementController.isJumping);
        animator.SetBool("isCrouching", playerMovementController.isCrouching);
        animator.SetBool("isPaused", FindObjectOfType<PlayerInputController>().paused);

        switch (switchMask.currentMask)
        {
            case MASKS.CROUCH:
                animator.SetInteger("Mask", 0);
                break;
            case MASKS.DOUBLEJUMP:
                animator.SetInteger("Mask", 1);
                break;
            case MASKS.ELEMENTALRESISTANCE:
                animator.SetInteger("Mask", 2);
                break;
            case MASKS.STRENGTH:
                animator.SetInteger("Mask", 3);
                break;
            default:
                break;
        }

       
        
    }
}
