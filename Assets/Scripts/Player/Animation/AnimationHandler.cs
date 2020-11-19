using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public SwitchMask switchMask;

    float horizontal;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        switchMask = FindObjectOfType<SwitchMask>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < -0.01f)
        {
            spriteRenderer.flipX = true;
        }

        switch(switchMask.currentMask)
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

        animator.SetFloat("Velocity", Mathf.Abs(horizontal));
    }
}
