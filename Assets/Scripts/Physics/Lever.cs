using UnityEngine;
using System.Collections;
using System;


public class Lever : MonoBehaviour
{

    public bool isActive;
    public GameObject interactable;

    void Start()
    {
        
    }

    public void PullLever()
    {
        if (!isActive)
        {
            interactable.GetComponent<Interactable>().Activate();
            isActive = true;
        }
        else
        {
            interactable.GetComponent<Interactable>().Deactivate();
            isActive = false;
        }
    }

}
