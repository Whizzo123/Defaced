using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInputController : MonoBehaviour
{


    public float HorizontalThreshold;
    private PlayerMovementController mv_controller;
    private PlayerHealthController h_controller;
    public SwitchMask switchMask { get; private set; }
    private Rigidbody2D playerBody;
    private GameObject objectBeingPushed;
    private GameObject objectBeingBroken;
    public bool paused;
    private Lever lever;
    private Generator gen;
    public Animator animator;
    public bool enableCheats;
    public MaskWheelSprite[] sprites;
    public AudioSystem audio { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        mv_controller = GetComponent<PlayerMovementController>();
        h_controller = GetComponent<PlayerHealthController>();
        switchMask = FindObjectOfType<SwitchMask>();
        FindObjectOfType<MaskWheel>().AddMaskToWheel(MASKS.CROUCH, sprites[0]);
        paused = false;
        switchMask.Switch(0);
        audio = FindObjectOfType<AudioSystem>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FindObjectOfType<DialogueManager>().isActive == false)
        {
            if (paused == false)
            {
                FindObjectOfType<PauseSystem>().PauseGame();
                paused = true;
            }
            else
            {
                FindObjectOfType<PauseSystem>().ResumeGame();
                paused = false;
            }
        }
        animator.SetFloat("Velocity", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if (!paused && !GetComponent<PlayerHealthController>().isDead)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > HorizontalThreshold)
            {
                //Move player
                mv_controller.Move(Input.GetAxisRaw("Horizontal"));
                if (!audio.IsSourcePlayingSound("Steps", this.gameObject) && mv_controller.onGround)
                {
                    audio.PlaySound("Steps", this.gameObject, true);
                }
                if(audio.IsSourcePlayingSound("Steps", this.gameObject) && !mv_controller.onGround)
                {
                    audio.StopSound(this.gameObject);
                }
            }
            else
            {
                if(audio.IsSourcePlayingSound("Steps", this.gameObject))
                {
                    audio.StopSound(this.gameObject);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Player jump
                mv_controller.Jump();
                if (audio.IsSourcePlayingSound("Steps", this.gameObject))
                {
                    audio.StopSound(this.gameObject);
                }
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (objectBeingBroken != null)
                {
                    Debug.Log("Object In To Destroy");
                    Destroy(objectBeingBroken);
                }
                if (lever != null)
                    lever.PullLever();
                if (gen != null)
                    gen.AttempToStart();
            }
            if (switchMask.currentMask == MASKS.CROUCH)
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
        if(this.transform.position.y < -1000f)
        {
            h_controller.Die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(switchMask.currentMask == MASKS.STRENGTH)
        {
            if(other.gameObject.tag == "Pushable")
            {
                if (other.gameObject.GetComponent<Rigidbody2D>())
                {
                    other.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    objectBeingPushed = other.gameObject;
                }
                else
                {
                    Debug.LogError("You've forgotten to attach a rigidbody to this!!");
                }
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
        if (other.gameObject.GetComponent<Generator>())
        {
            gen = other.gameObject.GetComponent<Generator>();
        }
        if (switchMask.currentMask == MASKS.STRENGTH)
        {
            if (other.gameObject.tag == "Breakable")
            {
                objectBeingBroken = other.gameObject;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject != null)
        {
            if (other.gameObject.GetComponent<Lever>())
            {
                lever = null;
            }
            if (other.gameObject.tag == "Breakable")
            {
                objectBeingBroken = null;
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
    
    }

}
