using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Image npcPortrait;
    public PauseSystem pauseSystem;
    public Animator animator;
    public bool isActive = false;
    private Queue<string> sentences;
    public NPC talkingNPC;

    void Start()
    {
        pauseSystem = FindObjectOfType<PauseSystem>();
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue");
        animator.SetBool("isActive", true);
        isActive = true;
        pauseSystem.FreezePlayer();
        nameText.text = dialogue.name;
        npcPortrait.sprite = talkingNPC.dialogueSprite;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(OutputSentence(sentence));
    }

    IEnumerator OutputSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isActive", false);
        isActive = false;
        pauseSystem.UnFreezePlayer();
        talkingNPC.GiveMask();
    }
}
