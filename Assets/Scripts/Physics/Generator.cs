using UnityEngine;
using System.Collections;
public class Generator : MonoBehaviour
{
    public bool isActive;
    public GameObject interactable;
    public void AttempToStart()
    {
        if (GetComponent<PlayerHealthController>().hasElementalResistance && !isActive)
        {
            if (interactable != null)
            {
                StartGenerator();
            }
            else
                Debug.LogWarning("You have a generator that is not linked up to an interactable");
        }
    }
    public void StartGenerator()
    {
        interactable.GetComponent<Interactable>().Activate();
        isActive = true;
        StartCoroutine(RunDuration());
        interactable.GetComponent<Interactable>().Deactivate();
        isActive = false;
    }
    IEnumerator RunDuration()
    {
        yield return new WaitForSeconds(10);
    }
}