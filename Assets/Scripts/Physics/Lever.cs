using UnityEngine;
using System.Collections;
using System;


public class Lever : MonoBehaviour
{

    public bool isActive;
    public GameObject[] interactables;

    public void PullLever()
    {
        FindObjectOfType<AudioSystem>().PlaySound("Switch", this.gameObject);
        for (int i = 0; i < interactables.Length; i++)
        {
            Debug.Log("CALLED");
            Interactable interactable = interactables[i].GetComponent<Interactable>();
            interactable.Toggle();
        }
    }

}
