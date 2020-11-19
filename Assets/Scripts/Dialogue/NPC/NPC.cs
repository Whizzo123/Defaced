using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{

    //make sure to create one for each npc
    public BoxCollider2D npcBoxCollider2D;
    public CapsuleCollider2D player;
    public Text PressE;
    public DialogueManager dialogueManager;
    DialogueTrigger dialogueTrigger;
    public Prerequisite prerequisite;
    public MASKS maskToGive;
    public MaskWheelSprite spriteToUseOnMaskWheel;
    public Sprite dialogueSprite;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }
    private void Update()
    {
        if(npcBoxCollider2D.IsTouching(player))
        {
            if(dialogueManager.isActive)
            {
                PressE.color = new Color(0, 0, 0, 0);
                
            }
            else
            {
                PressE.color = new Color(0, 0, 0, 1);
            }
            if (Input.GetKeyDown(KeyCode.E) && !dialogueManager.isActive)
            {
                dialogueManager.talkingNPC = this;
                dialogueTrigger.TriggerDialogue(this);
            }
            else if (Input.GetKeyDown(KeyCode.E) && dialogueManager.isActive)
            {
                dialogueManager.DisplayNextSentence();
            }
        }
        else
        {
            PressE.color = new Color(0, 0, 0, 0);
        }


    }

    public void GiveMask()
    {
        if (prerequisite == null)
        {
            FindObjectOfType<MaskWheel>().AddMaskToWheel(maskToGive, spriteToUseOnMaskWheel);
        }
        else
        {
            if (prerequisite.CheckAgainst(player.GetComponent<PlayerCollectionController>().collectedItems))
            {
                FindObjectOfType<MaskWheel>().AddMaskToWheel(maskToGive, spriteToUseOnMaskWheel);
            }
        }
    }
}
