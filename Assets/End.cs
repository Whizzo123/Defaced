using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(FindObjectOfType<MaskWheel>().GrabFreeComponent() == null)
        {
            SceneManager.LoadScene("EndCutscene");
        }
    }
}
