using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{

    private Animator doorAnimator;
    private BoxCollider2D doorCollider;

    public bool isOpen;

    void Start()
    {
        doorAnimator = GetComponent<Animator>();
        doorCollider = GetComponent<BoxCollider2D>();
    }

    public override void Toggle()
    {
        PlayAnimation(!isOpen);
    }


    void Update()
    {
        AnimatorStateInfo info = doorAnimator.GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime > 1f)
        {
            //Handle
            if (isOpen)
            {
                doorCollider.enabled = false;
            }
            else
            {
                doorCollider.enabled = true;
            }
        }
    }


    private void PlayAnimation(bool isOpening)
    {
        isOpen = isOpening;

        if (isOpen)
        {
            doorAnimator.Play("door_open");
        }
        else
        {
            doorAnimator.Play("door_close");
        }
    }
}
