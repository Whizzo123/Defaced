using UnityEngine;
using System.Collections;

public class PauseSystem : MonoBehaviour
{

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void FreezePlayer()
    {
        FindObjectOfType<PlayerInputController>().paused = true;
    }

    public void UnFreezePlayer()
    {
        FindObjectOfType<PlayerInputController>().paused = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}