using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CutsceneManager : MonoBehaviour
{

    public Sprite[] cutscenes;
    public Image screen;
    public int[] cutsceneDuration;
    public AudioSystem system;
    private float currentCutsceneDuration;

    private int cutsceneCounter;

    public string nextScene;

    void Start()
    {
        cutsceneCounter = 0;
        currentCutsceneDuration = cutsceneDuration[cutsceneCounter];
    }

    void Update()
    {
        if (cutsceneCounter < cutscenes.Length)
        {
            if (currentCutsceneDuration <= 0)
            {
                cutsceneCounter++;
                if (cutsceneCounter == 9)
                    system.PlaySound("Slap", screen.gameObject);
                screen.sprite = cutscenes[cutsceneCounter];
                currentCutsceneDuration = cutsceneDuration[cutsceneCounter];
            }
            currentCutsceneDuration -= Time.deltaTime;
        }
        else
        {
            //Load up next scene
            SceneManager.LoadScene(nextScene);
        }
    }

}
