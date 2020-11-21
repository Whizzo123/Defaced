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
    private bool closing;
    private Queue<string> sentences;
    public NPC talkingNPC;
    private Dictionary<string, Dialogue> characterDialogues;

    void Start()
    {
        pauseSystem = FindObjectOfType<PauseSystem>();
        sentences = new Queue<string>();
        characterDialogues = DialogueImporter.ImportCharacterDialogue();
        closing = false;
    }

    public void StartDialogue(string characterName)
    {
        animator.SetBool("isActive", true);
        isActive = true;
        pauseSystem.FreezePlayer();
        nameText.text = characterName;
        npcPortrait.sprite = talkingNPC.dialogueSprite;

        sentences.Clear();
        Dialogue dialogue = characterDialogues[characterName];
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            EndDialogue();
            closing = true;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("DialogueBox_Close") && closing)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if(info.normalizedTime > 1f)
            {
                Debug.Log("Passed time goal");
                isActive = false;
                closing = false;
            }
        }
        
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
        pauseSystem.UnFreezePlayer();
    }
}
