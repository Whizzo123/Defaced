using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue taskCompletionDialogue;
    public Dialogue taskUnfinishedDialogue;
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
            if(talkCounterCurrent < talkCounter)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(talkCounterDialogue[talkCounterCurrent]);
            }
        }
        else
        {
            if (thisNPC.prerequisite == null || thisNPC.prerequisite.CheckAgainst(thisNPC.player.GetComponent<PlayerCollectionController>().collectedItems))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(taskCompletionDialogue);
            }
            else
            {
                FindObjectOfType<DialogueManager>().StartDialogue(taskUnfinishedDialogue);
            }
        }
    }
}
