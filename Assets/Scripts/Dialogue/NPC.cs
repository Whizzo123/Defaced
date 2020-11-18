using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D player;
    public Text PressE;
    public DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }
    private void Update()
    {
        if(boxCollider2D.IsTouching(player))
        {
            PressE.color = new Color(0, 0, 0, 1);
            if(Input.GetKeyDown(KeyCode.E) && !dialogueManager.active)
            {
                dialogueTrigger.TriggerDialogue();   
            }
        }
        else
        {
            PressE.color = new Color(0, 0, 0, 1);
        }
    }
}
