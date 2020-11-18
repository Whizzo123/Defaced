using UnityEngine;
using System.Collections;

public class PauseSystem : MonoBehaviour
{

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}