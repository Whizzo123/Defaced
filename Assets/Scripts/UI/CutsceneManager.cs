using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CutsceneManager : MonoBehaviour
{

    public Sprite[] cutscenes;
    public Image screen;
    public int[] cutsceneDuration;

    private float currentCutsceneDuration;

    private int cutsceneCounter;

    public Scene nextScene;

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
                screen.sprite = cutscenes[cutsceneCounter];
                currentCutsceneDuration = cutsceneDuration[cutsceneCounter];
            }
            currentCutsceneDuration -= Time.deltaTime;
        }
        //Load up next scene
        SceneManager.LoadScene(nextScene.name);
    }

}
