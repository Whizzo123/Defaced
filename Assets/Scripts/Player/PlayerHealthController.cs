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

    void Start()
    {
        hasElementalResistance = false;
        lastCheckpoint = spawn;
    }

    public void Die()
    {
        this.transform.position = lastCheckpoint.transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == elementalDamageObjectTag)
        {
            if (!hasElementalResistance)
            {
                Debug.Log("Player dead");
                Die();
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
