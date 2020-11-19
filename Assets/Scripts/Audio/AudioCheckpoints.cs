using UnityEngine;
using System.Collections;



public class AudioCheckpoints : MonoBehaviour
{

    public string clipName;
    public GameObject musicPlayerGO;


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<PlayerMovementController>())
        {
            FindObjectOfType<AudioSystem>().PlayMusic(clipName, musicPlayerGO);
        }
    }

}
