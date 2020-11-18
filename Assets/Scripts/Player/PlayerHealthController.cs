using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;



public class PlayerHealthController : MonoBehaviour
{


    public string elementalDamageObjectTag;
    public bool hasElementalResistance;

    void Start()
    {
        hasElementalResistance = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == elementalDamageObjectTag)
        {
            if (!hasElementalResistance)
            {
                Debug.Log("Player dead");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {

    }



}
