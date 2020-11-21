using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;



public class PlayerHealthController : MonoBehaviour
{


    public string elementalDamageObjectTag;
    public string checkpointTag;
    private GameObject lastCheckpoint;
    public GameObject spawn;
    private AnimationHandler animHandler;
    private PlayerInputController input_controller;
    private bool markForDeath;
    public bool isDead
    {
        get
        {
            return markForDeath;
        }
        set
        {
            markForDeath = value;
            if (markForDeath)
                animHandler.animator.SetTrigger("Death");
        }
    }

    void Start()
    {
        lastCheckpoint = spawn;
        animHandler = GetComponent<AnimationHandler>();
        markForDeath = false;
        input_controller = GetComponent<PlayerInputController>();
    }

    public void Die()
    {
        this.transform.position = lastCheckpoint.transform.position;
        isDead = false;
    }

    void Update()
    {
        if(animHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("DEATH"))
        {
            Debug.Log("Inside death state");
            AnimatorStateInfo info = animHandler.animator.GetCurrentAnimatorStateInfo(0);
            Debug.Log("Normalized time: " + info.normalizedTime);
            if(info.normalizedTime > .99f)
            {
                Die();
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == elementalDamageObjectTag)
        {
            if (!(input_controller.switchMask.currentMask == MASKS.ELEMENTALRESISTANCE) && !other.gameObject.GetComponent<ElectricBlock>().IsToggled())
            {
                Debug.Log("Player dead");
                isDead = true;
            }
        }
        else if(other.gameObject.tag == checkpointTag)
        {
            lastCheckpoint = other.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

    }



}
