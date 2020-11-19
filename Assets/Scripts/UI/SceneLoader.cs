using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public string sceneName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
