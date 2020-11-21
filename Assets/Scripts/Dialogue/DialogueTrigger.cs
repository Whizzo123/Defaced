using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string characterName;
    public Dialogue[] talkCounterDialogue;
    private int talkCounter;
    private int talkCounterCurrent;
    public bool useTalkCounter;

    void Start()
    {
        talkCounterCurrent = 0;
        talkCounter = talkCounterDialogue.Length;
    }

    public void TriggerDialogue(NPC thisNPC)
    {
        if (useTalkCounter)
        {
            if (talkCounterCurrent < talkCounter)
            {
                //FindObjectOfType<DialogueManager>().StartDialogue(talkCounterDialogue[talkCounterCurrent]);
            }
            else
                thisNPC.GiveMask();
        }
        else
        {
            if (thisNPC.prerequisite == null || thisNPC.prerequisite.CheckAgainst(thisNPC.player.GetComponent<PlayerCollectionController>().collectedItems))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(characterName);
                thisNPC.GiveMask();
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(characterName);
            }
        }
    }
}
