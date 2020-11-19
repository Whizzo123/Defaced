using UnityEngine;
using System.Collections;
using System;


public class Lever : MonoBehaviour
{

    public bool isActive;
    public GameObject[] interactables;

    public void PullLever()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            interactables[i].GetComponent<Interactable>().Toggle();
        }
    }

}
