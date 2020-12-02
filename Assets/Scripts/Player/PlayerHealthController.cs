using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;



public class PlayerHealthController : MonoBehaviour
{


    public string elementalDamageObjectTag;
    public string checkpointTag;
    private AnimationHandler animHandler;
    private PlayerInputController input_controller;
    private bool markForDeath;
    public GameObject deathScreen;
    public Transform checkpoint;

    public bool isDead
    {
        get
        {
            return markForDeath;
        }
        set
        {
            
            if (value == true && markForDeath == false)
            {
                input_controller.m_audio.PlaySound("Death", this.gameObject);
                animHandler.animator.SetTrigger("Death");
                deathScreen.SetActive(true);
                markForDeath = value;
            }
            else
            {
                deathScreen.SetActive(false);
                markForDeath = value;
            }
        }
    }

    void Start()
    {
        checkpoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        animHandler = GetComponent<AnimationHandler>();
        markForDeath = false;
        input_controller = GetComponent<PlayerInputController>();

    }

    public void Die()
    {
        this.gameObject.transform.position = checkpoint.position;
        isDead = false;
    }

    void Update()
    {
        if(animHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("DEATH"))
        {
            AnimatorStateInfo info = animHandler.animator.GetCurrentAnimatorStateInfo(0);
            if(info.normalizedTime > .90f)
            {
                Die();
                deathScreen.SetActive(false);
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == elementalDamageObjectTag)
        {
            if (!(input_controller.switchMask.currentMask == MASKS.ELEMENTALRESISTANCE) && !other.gameObject.GetComponent<ElectricBlock>().IsToggled())
            {
                isDead = true;
            }
        }
       
        if(other.gameObject.tag == "Respawn") {
            checkpoint = other.gameObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

    }



}
