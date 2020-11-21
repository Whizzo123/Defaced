﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;



public class PlayerHealthController : MonoBehaviour
{


    public string elementalDamageObjectTag;
    public string checkpointTag;
    private GameObject spawn;
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
            
            if (value == true && markForDeath == false)
            {
                input_controller.audio.PlaySound("Death", this.gameObject);
                animHandler.animator.SetTrigger("Death");
                markForDeath = value;
            }
        }
    }

    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Respawn");
        animHandler = GetComponent<AnimationHandler>();
        markForDeath = false;
        input_controller = GetComponent<PlayerInputController>();
    }

    public void Die()
    {
        Debug.Log("About to teleport");
        this.gameObject.transform.position = new Vector2(-2.2f, 0.1f);
        Debug.Log("Teleported");
        isDead = false;
    }

    void Update()
    {
        if(animHandler.animator.GetCurrentAnimatorStateInfo(0).IsName("DEATH"))
        {
            Debug.Log("Inside death state");
            AnimatorStateInfo info = animHandler.animator.GetCurrentAnimatorStateInfo(0);
            Debug.Log("Normalized time: " + info.normalizedTime);
            if(info.normalizedTime > .90f)
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
       
    }

    void OnCollisionExit2D(Collision2D other)
    {

    }



}
