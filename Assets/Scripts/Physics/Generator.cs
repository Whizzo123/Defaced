using UnityEngine;
using System.Collections;
public class Generator : MonoBehaviour
{
    public bool isActive;
    public GameObject[] interactables;
    private SwitchMask switchMask;

    void Start()
    {
        switchMask = FindObjectOfType<SwitchMask>();
    }

    public void AttempToStart()
    {
        if (switchMask.currentMask == MASKS.ELEMENTALRESISTANCE && !isActive)
        {
            Debug.Log("GEN");
            if (interactables != null)
            {
                StartGenerator();
            }
            else
                Debug.LogWarning("You have a generator that is not linked up to an interactable");
        }
    }
    public void StartGenerator()
    {
        for (int i = 0; i < interactables.Length; i++)
        {
            Interactable interactable = interactables[i].GetComponent<Interactable>();
            interactable.Toggle();
            isActive = true;
        }

        StartCoroutine(RunDuration());
        for (int i = 0; i < interactables.Length; i++)
        {
            Interactable interactable = interactables[i].GetComponent<Interactable>();
            interactable.Toggle();
            isActive = false;
        }
    }
    IEnumerator RunDuration()
    {
        yield return new WaitForSeconds(10);
    }
}