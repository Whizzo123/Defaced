using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;



public class PlayerHealthController : MonoBehaviour
{


    public string elementalDamageObjectTag;
    public string checkpointTag;
    public bool hasElementalResistance;
    private GameObject lastCheckpoint;
    public GameObject spawn;
    private AnimationHandler animHandler;
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
        hasElementalResistance = false;
        lastCheckpoint = spawn;
        animHandler = GetComponent<AnimationHandler>();
        markForDeath = false;
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
            AnimatorStateInfo info = animHandler.animator.GetCurrentAnimatorStateInfo(0);
            if(info.normalizedTime > 1f)
            {
                Die();
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == elementalDamageObjectTag)
        {
            if (!hasElementalResistance && !other.gameObject.GetComponent<ElectricBlock>().IsToggled())
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
