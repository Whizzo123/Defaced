using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{


    public float HorizontalThreshold;
    private PlayerMovementController mv_controller;
    private PlayerHealthController h_controller;
    private Rigidbody2D playerBody;
    public bool hasStrength;
    private GameObject objectBeingPushed;
    private GameObject objectBeingBroken;
    public bool canCrouch;
    public bool paused;
    private Lever lever;
    public Animator animator;
    public bool enableCheats;
    public MaskWheelSprite[] sprites;

    void Start()
    {
        animator = GetComponent<Animator>();
        mv_controller = GetComponent<PlayerMovementController>();
        h_controller = GetComponent<PlayerHealthController>();
        if (!enableCheats)
        {
            hasStrength = false;
            FindObjectOfType<MaskWheel>().AddMaskToWheel(MASKS.CROUCH, sprites[0]);
            paused = false;
        }
        else
        {
            FindObjectOfType<MaskWheel>().AddMaskToWheel(MASKS.CROUCH, sprites[0]);
            FindObjectOfType<MaskWheel>().AddMaskToWheel(MASKS.DOUBLEJUMP, sprites[1]);
            FindObjectOfType<MaskWheel>().AddMaskToWheel(MASKS.STRENGTH, sprites[2]);
            FindObjectOfType<MaskWheel>().AddMaskToWheel(MASKS.ELEMENTALRESISTANCE, sprites[3]);
        }
        FindObjectOfType<SwitchMask>().Switch(0);
    }

    void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (!paused && !GetComponent<PlayerHealthController>().isDead)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > HorizontalThreshold)
            {
                //Move player
                mv_controller.Move(Input.GetAxisRaw("Horizontal"));
                
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Player jump
                mv_controller.Jump();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(objectBeingBroken != null)
                    Destroy(objectBeingBroken);
                if (lever != null)
                    lever.PullLever();
            }
            if (canCrouch)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    mv_controller.Crouch(true);
                }
                if (Input.GetKeyUp(KeyCode.S))
                {
                    mv_controller.Crouch(false);
                }
            }
        }
        if(this.transform.position.y < -20f)
        {
            h_controller.Die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(hasStrength)
        {
            if(other.gameObject.tag == "Pushable")
            {
                if (other.gameObject.GetComponent<Rigidbody2D>())
                {
                    Debug.Log("Pushing");
                    other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    objectBeingPushed = other.gameObject;
                }
                else
                    Debug.LogError("You've forgotten to attach a rigidbody to this!!");
            }
            if (other.gameObject.tag == "Breakable")
            {
                objectBeingBroken = other.gameObject;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<Lever>())
        {
            lever = other.gameObject.GetComponent<Lever>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.GetComponent<Lever>())
            {
                if (other.gameObject == lever.gameObject)
                {
                    lever = null;
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Pushable")
        {
            if(other.gameObject == objectBeingPushed)
            {
                other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                objectBeingPushed = null;
            }
        }
        if (other.gameObject.tag == "Breakable")
        {
            if (other.gameObject == objectBeingBroken)
            {
                objectBeingBroken = null;
            }
        }
    }

}
